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
						break;
					case 3:
						$('#next_page').prop('disabled', true);
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

			// var elements = document.getElementsByTagName("style");

			// if(elements.length > 0)
			// 	for (var i = elements.length - 1; i >= 0; i--) {
			// 		if(elements[i] !== undefined && elements[i].textContent == "")
	  //   				elements[i].parentNode.removeChild(elements[i]);
			// 	}
			
			$('div[id$="_section"]').css({'animation-name': 'slideLeft', '-webkit-animation-name': 'slideLeft'});
			$('#' + tabs.sections[currentPosition]).removeClass('d-none');
			tabs.active = currentPosition;
		}
	});

	// function slideTo() {
	// 	var style = document.documentElement.appendChild(document.createElement("style")),
	// 	rule = " anim {\
	// 	    0% {\
	// 	        transform: translateX(-100%);\
	// 	    }\
	// 	    14.28% {\
	// 	        transform: translateX(0);\
	// 	    }\
	// 	    85.71% {\
	// 	        transform: translateX(0);\
	// 	    }\
	// 	}";

	// 	if (CSSRule.KEYFRAMES_RULE) { // W3C
	// 	    style.sheet.insertRule("@keyframes" + rule, 0);
	// 	} else if (CSSRule.WEBKIT_KEYFRAMES_RULE) { // WebKit
	// 	    style.sheet.insertRule("@-webkit-keyframes" + rule, 0);
	// 	}
	// }
});