using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CVBuilder.ViewModels.Account
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage = ValMessages.FIELD_REQUIRED)]
        [MaxLength(100, ErrorMessage = ValMessages.MAX + "100" + ValMessages.CHARACTERS)]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = ValMessages.MAIL_VALID)]
        public string Email { get; set; }

        [Required(ErrorMessage = ValMessages.FIELD_REQUIRED)]
        [MinLength(8, ErrorMessage = ValMessages.MIN + "8" + ValMessages.CHARACTERS)]
        [MaxLength(100, ErrorMessage = ValMessages.MAX + "100" + ValMessages.CHARACTERS)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]).+$", ErrorMessage = ValMessages.PASSWORD_CHECKER)]
        public string Password { get; set; }

        [Required(ErrorMessage = ValMessages.FIELD_REQUIRED)]
        [Compare("Password", ErrorMessage = ValMessages.COMPARE_PASSWORD)]
        public string ConfirmPassword { get; set; }
        
        [Range(typeof(bool), "true", "true", ErrorMessage = ValMessages.ACCEPT_TERMS)]
        public bool TermsAndServices { get; set; }
    }
}