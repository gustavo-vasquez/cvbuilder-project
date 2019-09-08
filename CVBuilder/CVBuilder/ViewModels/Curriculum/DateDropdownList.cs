using CVBuilder.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVBuilder.ViewModels.Curriculum
{
    public class DateDropdownList
    {
        public List<SelectListItem> Days { get; set; }
        public List<SelectListItem> Months { get; set; }
        public List<SelectListItem> Years { get; set; }

        private readonly string[] _months = new string[] {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"};

        public DateDropdownList(DateType type)
        {
            Days = new List<SelectListItem>();
            Months = new List<SelectListItem>();
            int yearRangeStart, yearRangeCount;

            if (type == DateType.Birthday)
            {
                // Generación del combo con los dias
                IEnumerable<string> days = Enumerable.Range(1, 31).Select(n => n.ToString()).ToList();
                Days.Add(new SelectListItem() { Value = "0", Text = "Día", Selected = true });

                foreach (string day in days)
                    Days.Add(new SelectListItem() { Value = day, Text = day });

                // Rango del combo para los años
                yearRangeStart = DateTime.Now.Year - 78;
                yearRangeCount = (DateTime.Now.Year - 15) - yearRangeStart;
            }
            else
            {
                // Rango del combo para los años
                yearRangeStart = DateTime.Now.Year - 60;
                yearRangeCount = (DateTime.Now.Year - yearRangeStart) + 1;
            }

            // Generación del combo con los meses
            Months.Add(new SelectListItem() { Value = "0", Text = "Mes", Selected = true });

            if (type == DateType.CurriculumEndPeriod)
                Months.Add(new SelectListItem() { Value = "present", Text = "Actualidad" });

            if (type == DateType.CurriculumStartPeriod || type == DateType.CurriculumEndPeriod)
            {
                Months.Add(new SelectListItem() { Value = "not_show", Text = "No mostrar" });
                Months.Add(new SelectListItem() { Value = "only_year", Text = "Mostrar sólo el año" });
            }

            foreach (string month in _months)
                Months.Add(new SelectListItem() { Value = month, Text = month });

            // Generación del combo con los años
            IEnumerable<string> years = Enumerable.Range(yearRangeStart, yearRangeCount).OrderByDescending(n => n).Select(n => n.ToString()).ToList();
            Years = new List<SelectListItem>();
            Years.Add(new SelectListItem() { Value = "0", Text = "Año", Selected = true });

            foreach (string year in years)
                Years.Add(new SelectListItem() { Value = year, Text = year });
        }
    }
}