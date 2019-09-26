using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVBuilder.custom_validations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class EndYearGreaterThanAttribute : ValidationAttribute, IClientValidatable
    {
        private const string DefaultErrorMessage = "El año de finalización es menor que el inicio.";
        private readonly string _comparisonProperty;

        public EndYearGreaterThanAttribute(string comparisonProperty) : base (DefaultErrorMessage)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            int? currentValue = (int?)value;

            var comparisonProperty = validationContext.ObjectType.GetProperty(_comparisonProperty);
            var endMonthProperty = validationContext.ObjectType.GetProperty("EndMonth");

            if (comparisonProperty == null)
                throw new ArgumentException("No existe una propiedad con este nombre.");
            if (endMonthProperty == null)
                throw new ArgumentException("No existe la propiedad llamada EndMonth.");

            var comparisonValue = (int?)comparisonProperty.GetValue(validationContext.ObjectInstance);
            var endMonthValue = (string)endMonthProperty.GetValue(validationContext.ObjectInstance);

            if (currentValue < comparisonValue && comparisonValue != 0 && endMonthValue != Common.MonthOptions.Present)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule()
            {
                ValidationType = "validateendyear",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
            };

            rule.ValidationParameters.Add("startyear", _comparisonProperty);
            rule.ValidationParameters.Add("endmonthid", "#EndMonth");
            rule.ValidationParameters.Add("monthpresent", Common.MonthOptions.Present);

            yield return rule;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name);
        }
    }
}