using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVBuilder.enums
{
    public class FormIds
    {
        public static string PersonalDetails => SectionIds.PersonalDetails + Suffix;
        public static string Studies => SectionIds.Studies + Suffix;
        public static string WorkExperiences => SectionIds.WorkExperiences + Suffix;
        public static string Certificates => SectionIds.Certificates + Suffix;
        public static string Languages => SectionIds.Languages + Suffix;

        private const string Suffix = "_form";
    }
}