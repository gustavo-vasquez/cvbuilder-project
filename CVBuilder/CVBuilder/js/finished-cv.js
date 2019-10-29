const templates = ["/img/templates/classic.png", "/img/templates/elegant.png", "/img/templates/modern.png"];

$(document).ready(function () {
    $('#print_cv').on('click', printCV);

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

    $('#download_cv').on('click', downloadAsPdf);
});

function isEmptyOrSpaces(str) {
    return str === null || str.match(/^ *$/) !== null;
}

function printCV() {
    const node = $('.page')[0];
    var spinnerNode = getSpinnerNode(node, "print");
    node.parentNode.parentNode.insertBefore(spinnerNode, node.parentNode);

    let iframepreview = document.getElementById("iframepreview");

    if (iframepreview == null) {
        domtoimage.toSvg(node, { style: { 'margin': 0 } })
        .then(function (dataUrl) {
            let img = new Image();
            img.src = dataUrl;

            iframepreview = document.createElement("iframe");
            document.body.appendChild(iframepreview);
            iframepreview.id = "iframepreview"; // optional id
            iframepreview.name = "iframepreview";
            iframepreview.style = "display: none;";
            iframepreview.marginHeight = 0;
            iframepreview.marginWidth = 0;
            iframepreview.scrolling = "no";
            iframepreview.width = 794;
            iframepreview.height = 1123;
            iframepreview.contentDocument.body.appendChild(img);
        })
        .catch(function (error) {
            console.error('Error al preparar el curriculum.', error);
        });
    }
            
    setTimeout(function () {
        iframepreview.contentDocument.close(); // necessary for IE >= 10
        iframepreview.focus(); // necessary for IE >= 10*/
        iframepreview.contentWindow.print();
        spinnerNode.remove();
    }, 5000);
}

function downloadAsPdf() {
    const node = document.getElementsByClassName('page')[0];
    var spinnerNode = getSpinnerNode(node, "pdf");
    node.parentNode.parentNode.insertBefore(spinnerNode, node.parentNode);

    domtoimage.toJpeg(node, { style: { 'margin': 0 } })
    .then(function (dataUrl) {
        let pdf = new jsPDF('p', 'mm', 'a4');
        pdf.addImage(dataUrl, 'JPEG', 0, 0);
        pdf.save('cvbuilder.pdf');
        spinnerNode.remove();
    });
}

function getSpinnerNode(node, type) {
    var text;

    switch (type) {
        case 'print':
            text = "Preparando para imprimir";
            break;
        case 'pdf':
            text = "Generando el documento PDF";
            break;
        default:
            return false;
    }

    spinnerNode = document.createElement("h5");
    spinnerNode.id = "loading_print_pdf";
    spinnerNode.className = "h6 text-center mb-4";
    spinnerNode.innerHTML = '<img class="img-fluid" src="/img/spinners/spinner_3.gif" width="50" alt="generating_cv" />' + text + '...';

    return spinnerNode;
}
