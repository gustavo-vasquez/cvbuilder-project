using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVBuilder.custom_validations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class MaxFileSizeAttribute : ValidationAttribute, IClientValidatable
    {
        private const string DefaultErrorMessage = "El archivo es superior a {1} MB.";
        private readonly int _size;

        /// <summary>
        /// El peso máximo del archivo expresado en bytes.
        /// </summary>
        /// <param name="size"></param>
        public MaxFileSizeAttribute(int size) : base (DefaultErrorMessage)
        {
            _size = size;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                HttpPostedFileBase currentValue = (HttpPostedFileBase)value;

                if (currentValue.ContentLength > 0 && currentValue.ContentLength > _size)
                    return new ValidationResult(FormatErrorMessage(currentValue.FileName));
            }

            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule()
            {
                ValidationType = "validatemaxfilesize",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
            };

            rule.ValidationParameters.Add("size", _size);

            yield return rule;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, (_size / 1024) / 1024);
        }
    }
}