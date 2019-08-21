$(document).ready(function () {
	$('.cv-preview').on('mouseenter', function() {
		$(this).append('<div class="overlay"></div>');
		$(this).append('<button class="btn btn-sm btn-success">Cambiar plantilla</button>');
	}).on('mouseleave', function() {
		//$(this).children().last().remove();
		$('.cv-preview div[class="overlay"], .cv-preview button').remove();
	});

	var tabs = {
	 "active": 0,
	 "sections": [
	 			"personal_details_section",
	 			"studies_experiencies_section",
	 			"other_information_section",
	 			"custom_fields_section"
 			]
	};

	$('.tabs-group').on('click', 'button', function() {
		$('.tabs-group button').removeClass('active');

		for(var i = 0; i < tabs.sections.length; i++) {
			if($(this).data("value") == tabs.sections[i]) {
				tabs.active = i;

				$('div[id$="_section"]').css({'animation-name': 'slideDown', '-webkit-animation-name': 'slideDown'});
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

	$('#previous_page').on('click', function() {
		var currentPosition = tabs.active;

		if(currentPosition > 0 && currentPosition < tabs.sections.length) {
			$('#' + tabs.sections[currentPosition]).addClass('d-none');
			currentPosition--;

			if(currentPosition == tabs.sections.length - 2)
				$('#next_page').prop('disabled', false);

			if(currentPosition == 0)
				$(this).prop('disabled', true);

			$('div[id$="_section"]').css({'animation-name': 'slideRight', '-webkit-animation-name': 'slideRight'});
			$('#' + tabs.sections[currentPosition]).removeClass('d-none');
			tabs.active = currentPosition;

			$('.tabs-group button').removeClass('active');
			$('.tabs-group button[data-value=' + tabs.sections[currentPosition] + ']').addClass('active');
		}
	});

	$('#next_page').on('click', function() {
		var currentPosition = tabs.active;

		if(currentPosition >= 0 && currentPosition < tabs.sections.length) {
			$('#' + tabs.sections[currentPosition]).addClass('d-none');
			currentPosition++;

			if(currentPosition == 1)
				$('#previous_page').prop('disabled', false);

			if(currentPosition == tabs.sections.length - 1)
				$(this).prop('disabled', true);
			
			$('div[id$="_section"]').css({'animation-name': 'slideLeft', '-webkit-animation-name': 'slideLeft'});
			$('#' + tabs.sections[currentPosition]).removeClass('d-none');
			tabs.active = currentPosition;

			$('.tabs-group button').removeClass('active');
			$('.tabs-group button[data-value=' + tabs.sections[currentPosition] + ']').addClass('active');

			window.location.href = window.location.pathname + "#page-top";
		}
	});

	$(window).scrollStopped(function (ev) {
	    //console.log(ev);
	    isFormActionsWrapperInView();
	});

	isFormActionsWrapperInView();
});

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

function isFormActionsWrapperInView() {
    var $element = $('#form_actions');
    var isElementInView = Utils.isElementInView($('#form_actions_wrapper'), false);

    if (isElementInView) {
        if ($element.hasClass('form-actions-fixed'))
            $element.removeClass('form-actions-fixed');
    } else {
        if (!$element.hasClass('form-actions-fixed'))
            $element.addClass('form-actions-fixed');
    }
}