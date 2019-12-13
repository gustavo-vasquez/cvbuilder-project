using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Common
{
    public static class CurriculumGlobals
    {
        public const string DEFAULT_AVATAR_PATH = "/img/profile_coat.png";
        public const string DEFAULT_SUMMARY_TITLE = "Resumen profesional";
        public const string FACEBOOK_DOMAIN_START = "https://www.facebook.com/";
        public const string LINKEDIN_DOMAIN_START = "https://www.linkedin.com/in/";
        public const string GITHUB_DOMAIN_START = "https://github.com/";
        public const string TWITTER_DOMAIN_START = "https://twitter.com/";
        public const string CERTIFICATE_ONLINE_TEXT = "A distancia";
        public const string CERTIFICATE_CLASS_TEXT = "Presencial";
        public const string CERTIFICATE_INPROGRESS_TEXT = "En progreso";

        public static string GenerateStateInTimeFormat(string startMonth, int? startYear, string endMonth, int? endYear)
        {
            string stateInTime = string.Empty;

            if (startMonth != MonthOptions.None && endMonth != MonthOptions.None)
            {
                string startMonthFormatted = MonthOptions.MonthsComboBox[startMonth];
                string endMonthFormatted = MonthOptions.MonthsComboBox[endMonth];

                switch (startMonth)
                {
                    case MonthOptions.NotShow:
                        if (endMonth != MonthOptions.None && endMonth != MonthOptions.NotShow)
                        {
                            switch (endMonth)
                            {
                                case MonthOptions.Present:
                                    stateInTime = "(" + endMonthFormatted + ")";
                                    break;
                                case MonthOptions.OnlyYear:
                                    stateInTime = "(" + endYear + ")";
                                    break;
                                default:
                                    stateInTime = "(" + endMonthFormatted + " " + endYear + ")";
                                    break;
                            }
                        }
                        break;
                    case MonthOptions.OnlyYear:
                        if (endMonth != MonthOptions.None && endMonth != MonthOptions.NotShow)
                        {
                            switch (endMonth)
                            {
                                case MonthOptions.Present:
                                    stateInTime = "(" + startYear + "-" + endMonthFormatted + ")";
                                    break;
                                case MonthOptions.OnlyYear:
                                    stateInTime = "(" + startYear + "-" + endYear + ")";
                                    break;
                                default:
                                    stateInTime = "(" + startYear + "-" + endMonthFormatted + " " + endYear + ")";
                                    break;
                            }
                        }
                        break;
                    default:
                        if (endMonth != MonthOptions.None && endMonth != MonthOptions.NotShow)
                        {
                            switch (endMonth)
                            {
                                case MonthOptions.Present:
                                    stateInTime = "(" + startMonthFormatted + " " + startYear + "-" + endMonthFormatted + ")";
                                    break;
                                case MonthOptions.OnlyYear:
                                    stateInTime = "(" + startMonthFormatted + " " + startYear + "-" + endYear + ")";
                                    break;
                                default:
                                    stateInTime = "(" + startMonthFormatted + " " + startYear + "-" + endMonthFormatted + " " + endYear + ")";
                                    break;
                            }
                        }
                        break;
                }
            }

            return stateInTime;
        }
    }
}
