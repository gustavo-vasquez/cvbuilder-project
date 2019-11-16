$(document).ready(function () {
    // Smooth scrolling using jQuery easing
    $('a.js-scroll-trigger[href*="#"]:not([href="#"])').click(function () {
        if (location.pathname.replace(/^\//, '') === this.pathname.replace(/^\//, '') && location.hostname === this.hostname) {
            var target = $(this.hash);
            target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
            if (target.length) {
                $('html, body').animate({
                    scrollTop: target.offset().top - 48
                    //scrollTop: 0
                }, 1000, "easeInOutExpo");
                return false;
            }
        }
    });

	//$('.btn-myaccount').on('click', function() {
	//	location.href = "/Account/SignIn";
	//});
});

function splashSpinner(display, $element) {
    switch (display) {
        case true:
            $element.closest('div.row').after('<div id="spinner" class="text-center"><img src="/img/spinners/spinner_3.gif" width="50" alt="loading_form" /></div>');
            break;
        case false:
            $('#spinner').remove();
            break;
    }
}
