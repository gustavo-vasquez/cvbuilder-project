var tabs = {
    "active": 0,
    "sections": [
               "personal_details",
               "studies_experiencies",
               "other_information",
               "custom_fields"
    ]
};

$(document).ready(function () {
    displaySection(getQsParameterByName("section"));

	$('.cv-preview').on('mouseenter', function() {
		$(this).append('<div class="overlay"></div>');
		$(this).append('<button class="btn btn-sm btn-success">Cambiar plantilla</button>');
	}).on('mouseleave', function() {
		$('.cv-preview div[class="overlay"], .cv-preview button').remove();
	});

	$('.tabs-group').on('click', 'button', function() {
		$('.tabs-group button').removeClass('active');

		for(var i = 0; i < tabs.sections.length; i++) {
			if($(this).data("value") == tabs.sections[i]) {
				tabs.active = i;

				$('.cv-sections .card-body').css({ 'animation-name': 'slideDown', '-webkit-animation-name': 'slideDown' });
				$('#' + tabs.sections[i]).removeClass('d-none');
				$(this).addClass('active');

				switch(i) {
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
				$('#' + tabs.sections[i]).addClass('d-none');
			}
		}
	});

	$('.add-block').on('click', getSectionForm);

	$('#previous_page').on('click', function() {
		var currentPosition = tabs.active;

		if(currentPosition > 0 && currentPosition < tabs.sections.length) {
			$('#' + tabs.sections[currentPosition]).addClass('d-none');
			currentPosition--;

			if(currentPosition == tabs.sections.length - 2)
				$('#next_page').prop('disabled', false);

			if(currentPosition == 0)
				$(this).prop('disabled', true);

		    $('.cv-sections .card-body').css({ 'animation-name': 'slideRight', '-webkit-animation-name': 'slideRight' });
			$('#' + tabs.sections[currentPosition]).removeClass('d-none');
			tabs.active = currentPosition;

			$('.tabs-group button').removeClass('active');
			$('.tabs-group button[data-value=' + tabs.sections[currentPosition] + ']').addClass('active');
		}
	});

	$('#next_page').on('click', function () {
	    var currentPosition = tabs.active;

		if(currentPosition >= 0 && currentPosition < tabs.sections.length) {
			$('#' + tabs.sections[currentPosition]).addClass('d-none');
			currentPosition++;

			if(currentPosition == 1)
				$('#previous_page').prop('disabled', false);

			if(currentPosition == tabs.sections.length - 1)
				$(this).prop('disabled', true);
			
		    $('.cv-sections .card-body').css({ 'animation-name': 'slideLeft', '-webkit-animation-name': 'slideLeft' });
			$('#' + tabs.sections[currentPosition]).removeClass('d-none');
			tabs.active = currentPosition;

			$('.tabs-group button').removeClass('active');
			$('.tabs-group button[data-value=' + tabs.sections[currentPosition] + ']').addClass('active');

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
    for (var i = 0; i < tabs.sections.length; i++) {
        if (sectionName == tabs.sections[i]) {
            tabs.active = i;
            $('.tabs-group button[data-value=' + tabs.sections[i] + ']').addClass('active');

            if (i === 1) $('#previous_page').prop('disabled', true);
            else if (i === 3) $('#next_page').prop('disabled', true);
            $('#' + sectionName).removeClass('d-none');
        }
    }
    $('#' + tabs.sections[tabs.active]).removeClass('d-none');
    $('.tabs-group button[data-value=' + tabs.sections[tabs.active] + ']').addClass('active');
    $('#previous_page').prop('disabled', true);
}

function isScrolledIntoView(elem) {
    var docViewTop = $(window).scrollTop();
    var docViewBottom = docViewTop + $(window).height();

    var elemTop = $(elem).offset().top;
    var elemBottom = elemTop + $(elem).height();

    return ((elemBottom <= docViewBottom) && (elemTop >= docViewTop));
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
            return ((pageTop < elementTop) && (pageBottom > elementBottom));
        } else {
            return ((elementTop <= pageBottom) && (elementBottom >= pageTop));
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

function getSectionForm() {
    var $addBlockButton = $(this);

    $.ajax({
        url: "/Curriculum/GetSectionForm",
        type: "GET",
        contentType: "application/x-www-form-urlencoded",
        dataType: "html",
        success: function (result, status, xhr) {
            $('#' + $addBlockButton.data('value')).append(result);
            $addBlockButton.toggleClass('d-none');
            $('.remove-block').on('click', { addBlockButton: $addBlockButton }, deleteSectionBlock);
        }
    });
}

function deleteSectionBlock(e) {
    $(this).closest('form').remove();
    e.data.addBlockButton.toggleClass('d-none');
}

function onSectionFormSuccessful() {
    var elementId = $(this).parent().attr('id');

    $.ajax({
        url: "/Curriculum/GetSectionBlock",
        type: "GET",
        data: { area: elementId },
        contentType: "application/x-www-form-urlencoded",
        dataType: "html",
        success: function (result, status, xhr) {
            $('#' + elementId + ' .contracted-block-group').append(result);
        }
    });
}