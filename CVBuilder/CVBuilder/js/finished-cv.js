const templates = ["/img/templates/classic.png", "/img/templates/elegant.png", "/img/templates/modern.png"];

$(document).ready(function () {
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
                window.location.reload();
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

function isEmptyOrSpaces(str) {
    return str === null || str.match(/^ *$/) !== null;
}