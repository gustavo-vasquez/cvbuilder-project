$.validator.setDefaults({
    ignore: ""
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