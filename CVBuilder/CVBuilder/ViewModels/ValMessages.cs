using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVBuilder.ViewModels
{
    public static class ValMessages
    {
        public const string VALIDATIONPREFIX = "(*) ";
        public const string FIELD_REQUIRED = VALIDATIONPREFIX + "Campo obligatorio.";
        public const string LEVEL_REQUIRED = VALIDATIONPREFIX + "Nivel obligatorio.";
        public const string MIN = VALIDATIONPREFIX + "Mínimo ";
        public const string MAX = VALIDATIONPREFIX + "Máximo ";
        public const string CHARACTERS = " caracteres.";
        public const string NUMBERS = " números.";
        public const string MAIL_VALID = VALIDATIONPREFIX + "Escriba un correo válido.";
        public const string PASSWORD_CHECKER = VALIDATIONPREFIX + "Falta una minúscula, mayúscula o número.";
        public const string COMPARE_PASSWORD = VALIDATIONPREFIX + "Las contraseñas no coinciden.";
        public const string ACCEPT_TERMS = VALIDATIONPREFIX + "Debes aceptar para continuar.";
    }
}