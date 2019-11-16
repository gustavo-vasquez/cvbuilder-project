using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVBuilder.ViewModels.Account
{
    public class SignInViewModel
    {
        public UserRegisterModel RegisterModel { get; set; }
        public UserLoginModel LoginModel { get; set; }
    }
}