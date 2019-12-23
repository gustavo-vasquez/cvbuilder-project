using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVBuilder.ViewModels.Curriculum
{
    public class SummaryBlockViewModel
    {
        public int SummaryId { get; set; }
        public string Title { get; set; }
        public string StateInTime { get; set; }
        public bool IsVisible { get; set; }
    }
}