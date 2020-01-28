using CVBuilder.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVBuilder.custom_validations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class RequiredMonthPeriodAttribute : ValidationAttribute, IClientValidatable
    {
        private const string DefaultErrorMessage = "Elija un mes.";

        public RequiredMonthPeriodAttribute() : base (DefaultErrorMessage)
        {
            
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            string currentValue = (string)value;

            if (currentValue == MonthOptions.None)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule()
            {
                ValidationType = "validaterequiredmonthperiod",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
            };

            yield return rule;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name);
        }
    }
}