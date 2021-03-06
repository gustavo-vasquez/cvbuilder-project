﻿using CVBuilder.custom_validations;
using CVBuilder.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.ViewModels.Curriculum
{
    public class StudiesViewModel : SectionViewModelBase
    {
        public readonly DateDropdownList StartPeriod = new DateDropdownList(DateType.START_PERIOD);
        public readonly DateDropdownList EndPeriod = new DateDropdownList(DateType.END_PERIOD);

        public int StudyID { get; set; }
        [Required(ErrorMessage = ValMessages.FIELD_REQUIRED)]
        [MaxLength(100, ErrorMessage = ValMessages.MAX + "100" + ValMessages.CHARACTERS)]
        public string Title { get; set; }

        [Required(ErrorMessage = ValMessages.FIELD_REQUIRED)]
        [MaxLength(100, ErrorMessage = ValMessages.MAX + "100" + ValMessages.CHARACTERS)]
        public string Institute { get; set; }

        [Required(ErrorMessage = ValMessages.FIELD_REQUIRED)]
        [MaxLength(100, ErrorMessage = ValMessages.MAX + "100" + ValMessages.CHARACTERS)]
        public string City { get; set; }

        [RequiredMonthPeriod]
        public string StartMonth { get; set; }
        
        [RequiredYearPeriod("StartMonth")]
        [StartYearLessThan("EndYear")]
        public int? StartYear { get; set; }

        [RequiredMonthPeriod]
        public string EndMonth { get; set; }

        [RequiredYearPeriod("EndMonth")]
        [EndYearGreaterThan("StartYear")]
        public int? EndYear { get; set; }

        [MaxLength(300, ErrorMessage = ValMessages.MAX + "300" + ValMessages.CHARACTERS)]
        public string Description { get; set; }
        public bool IsVisible { get; set; }

        public StudiesViewModel()
        {
            base.FormId = FormIds.Studies;
            base.Type = FormType.ADD;
            this.IsVisible = true;
        }
    }
}
