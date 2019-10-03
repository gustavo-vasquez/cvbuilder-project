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
        public static string Certificates => SectionIds.Certificates + Suffix;
        public static string WorkExperiences => SectionIds.WorkExperiences + Suffix;
        public static string Languages => SectionIds.Languages + Suffix;
        public static string Skills => SectionIds.Skills + Suffix;
        public static string Interests => SectionIds.Interests + Suffix;
        public static string PersonalReferences => SectionIds.PersonalReferences + Suffix;
        public static string CustomFields => SectionIds.CustomFields + Suffix;

        private const string Suffix = "_form";
    }
}