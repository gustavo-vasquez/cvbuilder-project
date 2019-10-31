$.validator.setDefaults({
    ignore: ""
});

$.validator.unobtrusive.adapters.add('validatepostedfileextensions', ['extensions'], function (options) {
    var params = {
        extensions: options.params.extensions
    };
    options.rules['validatepostedfileextensions'] = params;
    options.messages['validatepostedfileextensions'] = options.message;
});

$.validator.addMethod('validatepostedfileextensions', function (value, element, params) {
    const fileExtension = value.toLowerCase().split('.').pop();
    return params.extensions.includes(fileExtension);
});

$.validator.unobtrusive.adapters.add('validatemaxfilesize', ['size'], function (options) {
    var params = {
        size: options.params.size
    };
    options.rules['validatemaxfilesize'] = params;
    options.messages['validatemaxfilesize'] = options.message;
});

$.validator.addMethod('validatemaxfilesize', function (value, element, params) {
    if (element.files.length > 0 && element.files[0].size > params.size)
        return false;

    return true;
});

$.validator.unobtrusive.adapters.add('validatestartyear', ['endyear'], function (options) {
    var params = {
        endYear: options.params.endyear
    };
    options.rules['validatestartyear'] = params;
    options.messages['validatestartyear'] = options.message;
});

$.validator.addMethod('validatestartyear', function (value, element, params) {
    var endYearValue = $('#' + params.endYear).val();
    if (value > endYearValue && endYearValue != 0)
        return false;

    return true;
});

$.validator.unobtrusive.adapters.add('validateendyear', ['startyear', 'endmonthid', 'monthpresent'], function (options) {
    var params = {
        startYear: options.params.startyear,
        endMonthId: options.params.endmonthid,
        monthPresent: options.params.monthpresent
    };
    options.rules['validateendyear'] = params;
    options.messages['validateendyear'] = options.message;
});

$.validator.addMethod('validateendyear', function (value, element, params) {
    var startYearValue = $('#' + params.startYear).val();
    if (value < startYearValue && startYearValue != 0 && $(params.endMonthId).val() != params.monthPresent)
        return false;

    return true;
});

$.validator.unobtrusive.adapters.add('validatecertificateyear', ['inprogress'], function (options) {
    var params = {
        inProgress: options.params.inprogress
    };
    options.rules['validatecertificateyear'] = params;
    options.messages['validatecertificateyear'] = options.message;
});

$.validator.addMethod('validatecertificateyear', function (value, element, params) {
    if (!$('#' + params.inProgress).get(0).checked && value == 0)
        return false;

    return true;
});

$.validator.unobtrusive.adapters.add('validaterequiredfromcombobox', ['allowemptystrings'], function (options) {
    var params = {
        allowEmptyStrings: options.params.allowemptystrings
    };
    options.rules['validaterequiredfromcombobox'] = params;
    options.messages['validaterequiredfromcombobox'] = options.message;
});

$.validator.addMethod('validaterequiredfromcombobox', function (value, element, params) {
    if (value === "none" || !params.allowEmptyStrings)
        return false;

    return true;
});