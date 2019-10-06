var tabs = {
    "active": 0,
    "pages": [
               "personal_details",
               "studies_experiencies",
               "other_information",
               "custom_sections"
    ]
};

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
		$(this).append('<button class="btn btn-sm btn-outline-success">Cambiar plantilla</button>');
	}).on('mouseleave', function() {
		$('.cv-preview div[class="overlay"], .cv-preview button').remove();
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

function generateThumbnail(event) {
    //Check File API support
    if (window.File && window.FileList && window.FileReader) {
        $this = $(this);

        if ($this.valid()) {
            var $thumbnailsRow = $(event.data.thumbnailsRowId);
            var buttonsToDisable, multimediaElement, createHTMLElements, filetype;

            switch ($this.attr('id')) {
                case "ImageFiles":
                    buttonsToDisable = "#newGifBtn, #newVideoBtn";
                    multimediaElement = ".images-upload-thumbnail";
                    filetype = "image";
                    createHTMLElements = function (picFile) {
                        // Creo los elementos con su contenido
                        var $wrapper = $('<div></div>');
                        $wrapper.attr({ "class": "col col-md-3" });
                        var $figure = $('<figure></figure>');
                        var $hidden = $('<input/>');
                        $hidden.attr({ type: "hidden", name: "ImagesUploaded", value: picFile.result });
                        var $img = $('<img/>');
                        $img.attr({ "class": multimediaElement.substring(1), src: picFile.result, title: picFile.fileName });
                        var $removeButton = $('<button></button>');
                        $removeButton.attr({ "class": "image-remove-thumbnail", type: "button", title: "Eliminar" });
                        $removeButton.html("&times;");

                        // Colocando los elementos creados
                        $hidden.appendTo($figure);
                        $img.appendTo($figure);
                        $removeButton.appendTo($figure);
                        $figure.appendTo($wrapper);
                        $wrapper.appendTo($thumbnailsRow);
                    };
                    break;
                case "GifImage":
                    buttonsToDisable = "#newImageBtn, #newVideoBtn";
                    multimediaElement = ".gif-upload-thumbnail";
                    filetype = "image";
                    createHTMLElements = function (picFile) {
                        // Creo los elementos con su contenido
                        var $wrapper = $('<div></div>');
                        $wrapper.attr({ "class": "col col-md-5" });
                        var $figure = $('<figure></figure>');
                        var $img = $('<img/>');
                        $img.attr({ "class": multimediaElement.substring(1), src: picFile.result, title: picFile.fileName });
                        var $removeButton = $('<button></button>');
                        $removeButton.attr({ "class": "gif-remove-thumbnail", type: "button", title: "Eliminar" });
                        $removeButton.html("&times;");

                        // Colocando los elementos creados
                        $img.appendTo($figure);
                        $removeButton.appendTo($figure);
                        $figure.appendTo($wrapper);
                        $wrapper.appendTo($thumbnailsRow);
                    };
                    break;
                case "VideoFile":
                    buttonsToDisable = "#newImageBtn, #newGifBtn";
                    multimediaElement = ".video-upload-thumbnail";
                    filetype = "video";
                    createHTMLElements = function (picFile) {
                        // Creo los elementos con su contenido
                        var $wrapper = $('<div></div>');
                        $wrapper.attr({ "class": "col" });
                        var $figure = $('<figure></figure>');
                        var $description = $('<div></div>');
                        $description.attr({ "class": "alert alert-dismissible alert-secondary" });
                        $description.html("<button type='button' class='close video-remove-thumbnail' title='Eliminar'>&times;</button><i class='fas fa-video'></i> " + picFile.fileName);
                        var $containerVideo = $('<div></div>');
                        $containerVideo.attr({ "class": "card embed-responsive embed-responsive-16by9" });
                        var $video = $('<video></video>');
                        $video.attr({ "class": multimediaElement.substring(1) + " embed-responsive-item", src: picFile.result, title: picFile.fileName, controls: "controls" });

                        // Colocando los elementos creados                        
                        $description.appendTo($figure);
                        $video.appendTo($containerVideo);
                        $containerVideo.appendTo($figure);
                        $figure.appendTo($wrapper);
                        $wrapper.appendTo($thumbnailsRow);
                    };
                    break;
                default:
                    return;
            }

            $(buttonsToDisable).addClass("disabled label-off");

            if ($this.attr('id') == "ImageFiles") {
                var files = event.target.files; //FileList object
                var filesCount = $('input[name=ImagesUploaded]').length + files.length;

                if (filesCount > 4)
                    return imageErrorMsg("length");
                else
                    $('.image-error-msg').remove();

                for (var i = 0; i < files.length; i++) {
                    var file = files[i];

                    if (!file.type.match(filetype))
                        continue;

                    filesTotalSize = filesTotalSize + files[i].size;

                    if (filesTotalSize > (2 * 1024 * 1024)) {
                        // Permitido hasta 2MB
                        filesTotalSize = filesTotalSize - files[i].size;
                        return imageErrorMsg("size");
                    }
                    else
                        $('.image-error-msg').remove();

                    var picReader = new FileReader();
                    picReader.fileName = file.name;

                    picReader.addEventListener("load", function (event) {
                        var picFile = event.target;
                        createHTMLElements(picFile);

                        $('.image-remove-thumbnail').on('click', function () {
                            $(this).closest("figure").parent("div").remove();

                            if ($thumbnailsRow.is(':empty')) {
                                $thumbnailsRow.addClass('d-none');
                                $(buttonsToDisable).removeClass("disabled label-off");
                            }

                            $this.val(null);
                        });
                    });

                    //Read the image
                    picReader.readAsDataURL(file);
                }

                if ($thumbnailsRow.hasClass('d-none')) {
                    $thumbnailsRow.removeClass('d-none');
                }
                return;
            }

            var file = event.target.files[0]; //FileList object

            if (!file.type.match(filetype))
                return;

            var picReader = new FileReader();
            picReader.fileName = file.name;

            picReader.addEventListener("load", function (event) {
                var picFile = event.target;

                if ($(multimediaElement).length > 0)
                    $(multimediaElement).attr({ src: picFile.result, title: picFile.fileName });
                else
                    createHTMLElements(picFile);

                $('.gif-remove-thumbnail, .video-remove-thumbnail').on('click', function () {
                    $(this).closest("figure").parent("div").remove();

                    if ($thumbnailsRow.is(':empty'))
                        $thumbnailsRow.addClass('d-none');

                    $(buttonsToDisable).removeClass("disabled label-off");
                    $this.val(null);
                });
            });

            //Read the image
            picReader.readAsDataURL(file);

            if ($thumbnailsRow.hasClass('d-none')) {
                $thumbnailsRow.removeClass('d-none');
            }
        }
    }
    else
        alert("Tu navegador no soporta File API");
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