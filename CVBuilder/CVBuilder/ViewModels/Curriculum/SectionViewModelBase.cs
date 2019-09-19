using CVBuilder.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVBuilder.ViewModels.Curriculum
{
    public abstract class SectionViewModelBase
    {
        public string FormId { get; set; }
        public FormType Type { get; set; }
    }
}