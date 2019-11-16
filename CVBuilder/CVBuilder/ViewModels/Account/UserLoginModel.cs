using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CVBuilder.ViewModels.Account
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = ValMessages.FIELD_REQUIRED)]
        public string Email { get; set; }

        [Required(ErrorMessage = ValMessages.FIELD_REQUIRED)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}