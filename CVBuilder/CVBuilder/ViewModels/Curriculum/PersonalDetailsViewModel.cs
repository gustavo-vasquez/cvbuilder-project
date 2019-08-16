﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.ViewModels.Curriculum
{
    public class PersonalDetailsViewModel
    {
        [Required(ErrorMessage = "Completar este campo.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Completar este campo.")]
        public string Name { get; set; }
        public string LastName { get; set; }
        public int IdentityCard { get; set; }
        public byte[] Photo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public short AreaCodeLP { get; set; }
        public int LinePhone { get; set; }
        public short AreaCodeMP { get; set; }
        public int MobilePhone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public string Summary { get; set; }
        public string SummaryCustomTitle { get; set; }
        public bool SummaryIsVisible { get; set; }
        public string WebPage { get; set; }
        public string LinkedInUrl { get; set; }
        public string Github { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
    }
}
