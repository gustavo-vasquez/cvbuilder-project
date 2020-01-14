using CVBuilder.Common;
using CVBuilder.custom_validations;
using CVBuilder.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CVBuilder.ViewModels.Curriculum
{
    public class LanguagesViewModel : SectionViewModelBase
    {
        public readonly List<SelectListItem> Levels;

        public int LanguageID { get; set; }

        [Required(ErrorMessage = "Completar este campo.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string Name { get; set; }

        [RequiredFromCombobox(ErrorMessage = "Nivel obligatorio.")]
        public string Level { get; set; }
        public bool IsVisible { get; set; }

        public LanguagesViewModel()
        {
            base.FormId = FormIds.Languages;
            base.Type = FormType.ADD;
            this.IsVisible = true;
            Levels = LevelsBox();
        }

        private List<SelectListItem> LevelsBox()
        {
            List<SelectListItem> levels = new List<SelectListItem>();
            levels.Add(new SelectListItem() { Value = LevelOptions.None, Text = "Nivel" });

            foreach (KeyValuePair<string, string> level in LevelOptions.LevelComboBox)
                levels.Add(new SelectListItem() { Value = level.Key, Text = level.Value });

            return levels;
        }
    }
}
