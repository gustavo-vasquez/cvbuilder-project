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
    public class RequiredFromComboboxAttribute : ValidationAttribute, IClientValidatable
    {
        private const string DefaultErrorMessage = "Campo obligatorio.";
        private readonly bool AllowEmptyStrings;

        public RequiredFromComboboxAttribute(bool allowEmptyStrings = false) : base (DefaultErrorMessage)
        {
            AllowEmptyStrings = allowEmptyStrings;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            string currentValue = (string)value;

            if (currentValue == LevelOptions.None || !AllowEmptyStrings)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule()
            {
                ValidationType = "validaterequiredfromcombobox",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
            };

            rule.ValidationParameters.Add("allowemptystrings", AllowEmptyStrings);

            yield return rule;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name);
        }
    }
}