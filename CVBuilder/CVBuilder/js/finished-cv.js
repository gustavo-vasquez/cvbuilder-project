const templates = ["/img/templates/classic.png", "/img/templates/elegant.png", "/img/templates/modern.png"];

$(document).ready(function () {
    var sum = 0;
    var pageBase;
    var heightBase = $('.page').height();
    let container = document.getElementById("curriculum_finished");

    switch (container.dataset.templateCv) {
        case "Classic":
            $('.page').children('div').each(function () {
                sum += $(this).outerHeight(true);

                if (sum > heightBase) {
                    pageBase = document.createElement("div");
                    pageBase.className = "col-auto page";
                    container.appendChild(pageBase);
                    pageBase.appendChild(this);
                    sum = $(this).outerHeight(true);
                }
                else if (pageBase !== undefined)
                    pageBase.appendChild(this);
            });
            break;
        case "Elegant":
            $leftPanel = $('.page .left-panel').first();
            heightBase = $leftPanel.height();
            $leftPanel.children('div').each(function () {
                sum += this.clientHeight;

                if (sum > heightBase) {
                    pageBase = document.createElement("div");
                    pageBase.className = "col-auto page";
                    pageBase.innerHTML = '<div class="row"><div class="col-4 left-panel"></div><div class="col-8 right-panel"></div></div>';
                    container.appendChild(pageBase);
                    pageBase = pageBase.getElementsByClassName("left-panel")[0];
                    pageBase.appendChild(this);
                    sum = this.clientHeight;
                }
                else if (pageBase !== undefined)
                    pageBase.appendChild(this);
            });

            sum = 0;
            $rightPanel = $('.page .right-panel').first();
            heightBase = $rightPanel.height();
            pageBase = undefined;
            pageNextIndex = 1;

            $rightPanel.children('div').each(function () {
                sum += this.clientHeight;

                if (sum > heightBase) {
                    pageBase = document.getElementsByClassName("page")[pageNextIndex];

                    if (pageBase === undefined) {
                        pageBase = document.createElement("div");
                        pageBase.className = "col-auto page";
                        pageBase.innerHTML = '<div class="row"><div class="col-4 left-panel"></div><div class="col-8 right-panel"></div></div>';
                        container.appendChild(pageBase);
                    }
                    
                    pageBase = pageBase.getElementsByClassName("right-panel")[0];
                    pageBase.appendChild(this);
                    sum = this.clientHeight;
                    pageNextIndex++;
                }
                else if (pageBase !== undefined)
                    pageBase.appendChild(this);
            });
            break;
        case "Modern":
            $leftPanel = $('.page .left-panel').first();
            heightBase = $leftPanel.height();
            $leftPanel.children('div').each(function () {
                sum += this.clientHeight;

                if (sum > heightBase) {
                    pageBase = document.createElement("div");
                    pageBase.className = "col-auto page";
                    pageBase.innerHTML = '<div class="row"><div class="col-4 left-panel"></div><div class="col-8 right-panel"></div></div>';
                    container.appendChild(pageBase);
                    pageBase = pageBase.getElementsByClassName("left-panel")[0];
                    pageBase.appendChild(this);
                    sum = this.clientHeight;
                    heightBase = $(pageBase).height();
                }
                else if (pageBase !== undefined)
                    pageBase.appendChild(this);
            });

            sum = 0;
            $rightPanel = $('.page .right-panel').first();
            heightBase = $rightPanel.height();
            pageBase = undefined;
            pageNextIndex = 1;

            $rightPanel.children('div').each(function () {
                sum += this.clientHeight;

                if (sum > heightBase) {
                    pageBase = document.getElementsByClassName("page")[pageNextIndex];

                    if (pageBase === undefined) {
                        pageBase = document.createElement("div");
                        pageBase.className = "col-auto page";
                        pageBase.innerHTML = '<div class="row"><div class="col-4 left-panel"></div><div class="col-8 right-panel"></div></div>';
                        container.appendChild(pageBase);
                    }
                    
                    pageBase = pageBase.getElementsByClassName("right-panel")[0];
                    pageBase.appendChild(this);
                    sum = this.clientHeight;
                    heightBase = $(pageBase).height();
                    pageNextIndex++;
                }
                else if (pageBase !== undefined)
                    pageBase.appendChild(this);
            });
            break;
        default:
            alert("Error, no se pudo analizar el paginado del curriculum.");
    }

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
    const pageNodes = document.getElementsByClassName("page");
    var spinnerNode = getSpinnerNode("print");
    pageNodes[0].parentNode.parentNode.insertBefore(spinnerNode, pageNodes[0].parentNode);

    let iframepreview = document.getElementById("iframepreview");

    if (iframepreview == null) {
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

        generatePrintPreview(pageNodes, iframepreview);
    }
    
    setTimeout(function () {
        iframepreview.contentDocument.close(); // necessary for IE >= 10
        iframepreview.focus(); // necessary for IE >= 10*/
        iframepreview.contentWindow.print();
        spinnerNode.remove();
    }, 3300 * pageNodes.length);
}

async function generatePrintPreview(pageNodes, iframepreview) {
    for (var i = 0; i < pageNodes.length; i++) {
        const dataUrl = await (convertToImage(pageNodes[i], "svg"));
        let img = new Image();
        img.src = dataUrl;
        iframepreview.contentDocument.body.appendChild(img);
    }
};

async function generatePdfDocument(pageNodes) {
    let pdf = new jsPDF('p', 'mm', 'a4');

    for (var i = 0; i < pageNodes.length; i++) {
        if (i !== 0)
            pdf.addPage();

        const dataUrl = await (convertToImage(pageNodes[i], "jpeg"));
        pdf.addImage(dataUrl, 'JPEG', 0, 0);
    }

    pdf.save('cvbuilder.pdf');
    spinnerNode.remove();
};

async function convertToImage(pageNode, imageType) {
    switch (imageType) {
        case "svg":
            return await(domtoimage.toSvg(pageNode, { style: { 'margin': 0 } }));
        case "jpeg":
            return await(domtoimage.toJpeg(pageNode, { style: { 'margin': 0 } }));
        default:
            break;
    }
};

function downloadAsPdf() {
    const pageNodes = document.getElementsByClassName('page');
    var spinnerNode = getSpinnerNode("pdf");
    pageNodes[0].parentNode.parentNode.insertBefore(spinnerNode, pageNodes[0].parentNode);
    generatePdfDocument(pageNodes);
}

function getSpinnerNode(type) {
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
    spinnerNode.className = "h6 position-relative text-center mb-4";
    spinnerNode.innerHTML = '<img class="img-fluid" src="/img/spinners/spinner_3.gif" width="50" alt="generating_cv" />' + text + '...';

    return spinnerNode;
}
