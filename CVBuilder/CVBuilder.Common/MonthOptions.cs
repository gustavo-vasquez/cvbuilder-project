using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Common
{
    public static class MonthOptions
    {
        public const string None = "none";
        public const string NotShow = "not_show";
        public const string OnlyYear = "only_year";
        public const string Present = "present";
        public const string January = "january";
        public const string February = "february";
        public const string March = "march";
        public const string April = "april";
        public const string May = "may";
        public const string June = "june";
        public const string July = "july";
        public const string August = "august";
        public const string September = "september";
        public const string October = "october";
        public const string November = "november";
        public const string December = "december";

        public static Dictionary<string, string> MonthsComboBox = new Dictionary<string, string>()
        {
            { NotShow, "No mostrar" },
            { OnlyYear, "Mostrar sólo el año" },
            { Present, "Actualidad" },
            { January, "Enero" },
            { February, "Febrero" },
            { March, "Marzo" },
            { April, "Abril" },
            { May, "Mayo" },
            { June, "Junio" },
            { July, "Julio" },
            { August, "Agosto" },
            { September, "Septiembre" },
            { October, "Octubre" },
            { November, "Noviembre" },
            { December, "Diciembre" },
        };
    }
}
