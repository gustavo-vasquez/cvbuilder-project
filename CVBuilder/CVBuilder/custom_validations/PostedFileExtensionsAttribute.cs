using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CVBuilder.custom_validations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PostedFileExtensionsAttribute : ValidationAttribute, IClientValidatable
    {
        private const string DefaultErrorMessage = "Tipo de archivo no permitido.";
        private readonly string[] _extensions;

        /// <summary>
        /// Extensiones de archivo permitidas (separadas por coma).
        /// </summary>
        /// <param name="extensions"></param>
        public PostedFileExtensionsAttribute(string extensions) : base (DefaultErrorMessage)
        {
            _extensions = extensions.Split(',');
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                HttpPostedFileBase currentValue = (HttpPostedFileBase)value;
                string extension = Path.GetExtension(currentValue.FileName).ToLower().Replace(".", "");

                if (!_extensions.Contains(extension))
                    return new ValidationResult(FormatErrorMessage(currentValue.FileName));
            }

            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule()
            {
                ValidationType = "validatepostedfileextensions",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
            };

            rule.ValidationParameters.Add("extensions", new JavaScriptSerializer().Serialize(_extensions));

            yield return rule;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name);
        }
    }
}