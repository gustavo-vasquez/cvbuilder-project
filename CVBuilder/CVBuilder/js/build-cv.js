var tabs = {
    "active": 0,
    "pages": [
               "personal_details",
               "studies_experiencies",
               "other_information",
               "custom_sections"
    ]
};

const templates = ["/img/templates/classic.png", "/img/templates/elegant.png", "/img/templates/modern.png"];

$(window).resize(function () {
    // 576 -> pantalla móvil | 768 -> pantalla tablet
    const width = $(this).innerWidth();

    if (width <= 768 && $('.btn-group-row .list-group').length === 0) {
        $('.btn-group-row .btn-group').addClass('list-group').removeClass('btn-group');
        $('.btn-group-row .list-group > button').addClass('mb-1');
    }
    else if (width > 768 && $('.btn-group-row .btn-group').length === 0) {
        // pantalla escritorio
        $('.btn-group-row .list-group').addClass('btn-group').removeClass('list-group');
        $('.btn-group-row .btn-group > button').removeClass('mb-1');
    }
});

$(document).ready(function () {
    displaySection(getQsParameterByName("section"));

	$('.cv-preview').on('mouseenter', function() {
		$(this).append('<div class="overlay"></div>');
		$('#choose_template').removeClass('invisible');
	}).on('mouseleave', function() {
	    $('.cv-preview div[class="overlay"]').remove();
	    $('#choose_template').addClass('invisible');
	});

	$('.tabs-group').on('click', 'button', function() {
		$('.tabs-group button').removeClass('active');

		for(var i = 0; i < tabs.pages.length; i++) {
			if($(this).data("value") === tabs.pages[i]) {
				tabs.active = i;

				$('.cv-sections .card-body').css({ 'animation-name': 'slideDown', '-webkit-animation-name': 'slideDown' });
				$('#' + tabs.pages[i]).removeClass('d-none');
				$(this).addClass('active');

				switch (i) {
				    case 0:
				        $('#previous_page').prop('disabled', true);
				        if ($('#next_page').prop('disabled'))
					        $('#next_page').prop('disabled', false);
						break;
					case 3:
					    $('#next_page').prop('disabled', true);
					    if ($('#previous_page').prop('disabled'))
					        $('#previous_page').prop('disabled', false);
						break;
					default:
						$('#previous_page').prop('disabled', false);
						$('#next_page').prop('disabled', false);
						break;
				}
			}
			else {
				$('#' + tabs.pages[i]).addClass('d-none');
			}
		}
	});

	$('.profile-photo').on('click', function () { $('#UploadedPhoto').trigger('click') });
	$('#UploadedPhoto').on('change', profilePicturePreview);
	$('.add-block').on('click', getSectionForm);
	$('.contracted-block-group').on('click', '.edit-block', editSectionForm);
	$('.contracted-block-group').on('click', '.remove-block', removeBlock);

	$('#previous_page').on('click', function() {
	    var currentPosition = tabs.active;

		if(currentPosition > 0 && currentPosition < tabs.pages.length) {
			$('#' + tabs.pages[currentPosition]).addClass('d-none');
			currentPosition--;

			if(currentPosition === tabs.pages.length - 2)
				$('#next_page').prop('disabled', false);

			if(currentPosition === 0)
				$(this).prop('disabled', true);

		    $('.cv-sections .card-body').css({ 'animation-name': 'slideRight', '-webkit-animation-name': 'slideRight' });
			$('#' + tabs.pages[currentPosition]).removeClass('d-none');
			tabs.active = currentPosition;

			$('.tabs-group button').removeClass('active');
			$('.tabs-group button[data-value=' + tabs.pages[currentPosition] + ']').addClass('active');
		}
	});

	$('#next_page').on('click', function () {
	    var currentPosition = tabs.active;

		if(currentPosition >= 0 && currentPosition < tabs.pages.length) {
			$('#' + tabs.pages[currentPosition]).addClass('d-none');
			currentPosition++;

			if(currentPosition === 1)
				$('#previous_page').prop('disabled', false);

			if(currentPosition === tabs.pages.length - 1)
				$(this).prop('disabled', true);
			
		    $('.cv-sections .card-body').css({ 'animation-name': 'slideLeft', '-webkit-animation-name': 'slideLeft' });
			$('#' + tabs.pages[currentPosition]).removeClass('d-none');
			tabs.active = currentPosition;

			$('.tabs-group button').removeClass('active');
			$('.tabs-group button[data-value=' + tabs.pages[currentPosition] + ']').addClass('active');

		    //window.location.href = window.location.pathname + "#page-top";
			
		}
	});

	$(window).scrollStopped(function (ev) {
	    //console.log(ev);
	    navigationButtonsWrapperInView();
	});

	navigationButtonsWrapperInView();

	$('#template_wizard').on('show.bs.modal', function (e) {
	    $('.cv-preview-img').attr('src', $('.cv-preview img').attr('src'));
	})

	$('#changeTemplate').on('click', function () {
	    const previewPath = $('.cv-preview-img').attr('src');

	    $.ajax({
	        url: "/Curriculum/ChangeTemplate",
	        type: "GET",
	        data: { path: previewPath },
	        //beforeSend: function (xhr) {
	        //    splashSpinner(true, $addBlockButton);
	        //},
	        success: function (result, status, xhr) {
	            $('.cv-preview img').attr('src', previewPath);
	            $('#template_wizard').modal('hide');
	        },
	        //complete: function (xhr, status) {
	        //    splashSpinner(false);
	        //}
	        error: function (event, xhr, options, exc) {
	            alert('Error al cambiar de plantilla.');
	        }
	    });
	});
});

// FUNCIONES

function getQsParameterByName(name) {
    try {
        const urlParams = new URLSearchParams(window.location.search);

        return urlParams.get('section');
    }
    catch (err) {
        name = name.replace(/[\[\]]/g, '\\$&');
        var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(window.location.href);
        if (!results) return null;
        if (!results[2]) return '';

        return decodeURIComponent(results[2].replace(/\+/g, ' '));
    }
}

function displaySection(sectionName) {
    for (var i = 0; i < tabs.pages.length; i++) {
        if (sectionName === tabs.pages[i]) {
            tabs.active = i;
            $('.tabs-group button[data-value=' + tabs.pages[i] + ']').addClass('active');

            if (i === 1) $('#previous_page').prop('disabled', true);
            else if (i === 3) $('#next_page').prop('disabled', true);
            $('#' + sectionName).removeClass('d-none');
        }
    }
    $('#' + tabs.pages[tabs.active]).removeClass('d-none');
    $('.tabs-group button[data-value=' + tabs.pages[tabs.active] + ']').addClass('active');
    $('#previous_page').prop('disabled', true);
}

function isScrolledIntoView(elem) {
    var docViewTop = $(window).scrollTop();
    var docViewBottom = docViewTop + $(window).height();

    var elemTop = $(elem).offset().top;
    var elemBottom = elemTop + $(elem).height();

    return elemBottom <= docViewBottom && elemTop >= docViewTop;
}

function Utils() { }

Utils.prototype = {
    constructor: Utils,
    isElementInView: function (element, fullyInView) {
        var pageTop = $(window).scrollTop();
        var pageBottom = pageTop + $(window).height();
        var elementTop = $(element).offset().top;
        var elementBottom = elementTop + $(element).height();

        if (fullyInView === true) {
            return pageTop < elementTop && pageBottom > elementBottom;
        } else {
            return elementTop <= pageBottom && elementBottom >= pageTop;
        }
    }
};

var Utils = new Utils();

$.fn.scrollStopped = function (callback) {
    var that = this, $this = $(that);
    $this.scroll(function (ev) {
        clearTimeout($this.data('scrollTimeout'));
        $this.data('scrollTimeout', setTimeout(callback.bind(that), 150, ev));
    });
};

function isEmptyOrSpaces(str) {
    return str === null || str.match(/^ *$/) !== null;
}

$('.btn-wizard-arrow').on('click', function (e) {
    const type = $(this).data('type');
    const $template = $(this).siblings('img').first();
    var imagePath = "";

    switch (type) {
        case "back":
            switch ($template.attr('src')) {
                case templates[0]:
                    imagePath = templates[2];
                    break;
                case templates[1]:
                    imagePath = templates[0];
                    break;
                case templates[2]:
                    imagePath = templates[1];
                    break;
                default:
                    break;
            }
            break;
        case "next":
            switch ($template.attr('src')) {
                case templates[0]:
                    imagePath = templates[1];
                    break;
                case templates[1]:
                    imagePath = templates[2];
                    break;
                case templates[2]:
                    imagePath = templates[0];
                    break;
                default:
                    break;
            }
            break;
        default:
            break;
    }

    if (!isEmptyOrSpaces(imagePath))
        $template.attr('src', imagePath);
});

function navigationButtonsWrapperInView() {
    var $element = $('#navigation_buttons');
    var isElementInView = Utils.isElementInView($('#navigation_buttons_wrapper'), false);

    if (isElementInView) {
        if ($element.hasClass('navigation-buttons-fixed'))
            $element.removeClass('navigation-buttons-fixed');
    } else {
        if (!$element.hasClass('navigation-buttons-fixed'))
            $element.addClass('navigation-buttons-fixed');
    }
}

function profilePicturePreview(e) {
    if (window.File && window.FileList && window.FileReader) {
        var inputFile = this;

        if ($(this).valid() && inputFile.files && inputFile.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                document.getElementsByClassName('profile-photo')[0].style.backgroundImage = "url(" + e.target.result + ")";
            }

            reader.readAsDataURL(inputFile.files[0]);
        }
    }
    else
        alert("Tu navegador no soporta File API.");
}

function getSectionForm() {
    var $addBlockButton = $(this);
    const section = $addBlockButton.closest('section').attr('id');

    $.ajax({
        url: "/Curriculum/GetSectionForm",
        type: "GET",
        data: { section: section },
        contentType: "application/x-www-form-urlencoded",
        dataType: "html",
        beforeSend: function (xhr) {
            splashSpinner(true, $addBlockButton);
        },
        success: function (result, status, xhr) {
            $('#' + section).append(result);
            $.validator.unobtrusive.parse("form");
            $addBlockButton.toggleClass('d-none');
            $('#' + section + ' form input:text').first().focus();

            if (section === "studies" || section === "work_experiences")
                $('#StartMonth, #EndMonth').on('change', monthBoxActions);
            else if (section === "certificates") {
                $('#' + section).on('change', '#InProgress', function () { toggleCertificateYear(section, this); });
            }
            
            $('.remove-form-block').on('click', { addBlockButton: $addBlockButton }, removeNewBlock);
        },
        complete: function (xhr, status) {
            splashSpinner(false);
        }
    });
}

function editSectionForm() {
    var $editBlockButton = $(this);
    const section = $editBlockButton.closest('section').attr('id');

    $.ajax({
        url: "/Curriculum/EditSectionForm",
        type: "GET",
        data: { section: section, id: $editBlockButton.data('id') },
        contentType: "application/x-www-form-urlencoded",
        dataType: "html",
        beforeSend: function (xhr) {
            splashSpinner(true, $editBlockButton);
        },
        success: function (result, status, xhr) {
            $editBlockButton.closest('.card-body').append(result);
            $.validator.unobtrusive.parse("form");
            $editBlockButton.toggleClass('invisible');
            $('#' + section + ' form input:text').first().focus();

            if (section === "studies" || section === "work_experiences")
                $('#StartMonth, #EndMonth').on('change', monthBoxActions);
            else if (section === "certificates") {
                toggleCertificateYear(section, document.getElementById('InProgress'));
                $('#' + section).on('change', '#InProgress', function () { toggleCertificateYear(section, this); });
            }

            $('.remove-form-block').on('click', function () { $editBlockButton.siblings('.remove-block').trigger('click'); });
        },
        complete: function (xhr, status) {
            splashSpinner(false);
        }
    });
}

function toggleCertificateYear(section, inProgress) {
    if (inProgress.checked)
        $('#' + section + ' #Year').addClass('invisible');
    else
        $('#' + section + ' #Year').removeClass('invisible');
}

function removeNewBlock(e) {
    $(this).closest('form').remove();
    e.data.addBlockButton.toggleClass('d-none');
}

function successfulMessage(result, status, xhr) {
    $form = $(result.formid);
    $form.append('<div id="successfulMessage" class="alert alert-success text-center mt-3 mb-0 style="display: none;">' + unescape('%A1') + 'Cambios guardados!</div>');
    $('#successfulMessage').delay(4000).fadeOut('slow', function () { $('#successfulMessage').remove(); });
}

function onErrorSubmit(event, xhr, options, exc) {
    console.log(event.responseText);
}

function onSectionFormSuccessful(result, status, xhr) {
    $form = $(result.formid);
    const section = $form.closest('section').attr('id');

    $.ajax({
        url: "/Curriculum/GetSectionBlock",
        type: "GET",
        data: { section: section, id: result.id },
        contentType: "application/x-www-form-urlencoded",
        dataType: "html",
        success: function (vresult, status, xhr) {
                switch(result.mode) {
                    case 0:
                        $form.fadeOut(function () {
                            $('#' + section + ' .add-block').toggleClass('d-none');
                            $('#' + section + ' .contracted-block-group').append(vresult);
                            $form.remove();
                        });
                        break;
                    case 1:
                        const $block = $form.closest('.contracted-block');
                        const $nextBlock = $block.next();
                        $block.remove();
                        $nextBlock.length > 0 ? $nextBlock.before(vresult) : $('#' + section + ' .contracted-block-group').append(vresult);
                        break;
                    default:
                        break;
                }
                
                
        }
    });
}

function removeBlock() {
    const $this = $(this);
    var r = confirm(unescape('%BF') + "Est" + unescape('%E1') + " seguro?");

    if (r) {
        $.ajax({
            url: "/Curriculum/RemoveBlock",
            type: "POST",
            data: { section: $this.closest('section').attr('id'), id: $this.data('id') },
            success: function (result, status, xhr) {
                $this.closest(".contracted-block").fadeOut(function () { $this.closest(".contracted-block").remove(); });
            }
        });
    }
}

function monthBoxActions() {
    const selectId = this.id;
    const optionValue = this.value;
    var $targetComboBox;
    
    switch(selectId) {
        case "StartMonth":
            $targetComboBox = $('#StartYear');
            if (optionValue === "not_show")
                $targetComboBox.addClass('invisible');
            else if ($targetComboBox.hasClass('invisible'))
                $targetComboBox.removeClass('invisible');
            break;
        case "EndMonth":
            $targetComboBox = $('#EndYear');
            if (optionValue === "not_show" || optionValue === "present")
                $targetComboBox.addClass('invisible');
            else if ($targetComboBox.hasClass('invisible'))
                $targetComboBox.removeClass('invisible');
            break;
        default:
            break;
    }
}
