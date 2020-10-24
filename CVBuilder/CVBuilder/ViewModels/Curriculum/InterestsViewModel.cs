﻿using CVBuilder.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.ViewModels.Curriculum
{
    public class InterestsViewModel : SectionViewModelBase
    {
        public int InterestID { get; set; }

        [Required(ErrorMessage = ValMessages.FIELD_REQUIRED)]
        [MaxLength(100, ErrorMessage = ValMessages.MAX + "100" + ValMessages.CHARACTERS)]
        public string Name { get; set; }
        public bool IsVisible { get; set; }

        public InterestsViewModel()
        {
            base.FormId = FormIds.Interests;
            base.Type = FormType.ADD;
            this.IsVisible = true;
        }
    }
}
