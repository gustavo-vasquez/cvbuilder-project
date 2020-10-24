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
    public class SkillsViewModel : SectionViewModelBase
    {
        public readonly List<SelectListItem> Levels;

        public int SkillID { get; set; }

        [Required(ErrorMessage = ValMessages.FIELD_REQUIRED)]
        [MaxLength(100, ErrorMessage = ValMessages.MAX + "100" + ValMessages.CHARACTERS)]
        public string Name { get; set; }

        [RequiredFromCombobox(ErrorMessage = ValMessages.LEVEL_REQUIRED)]
        public string Level { get; set; }
        public bool IsVisible { get; set; }

        public SkillsViewModel()
        {
            base.FormId = FormIds.Skills;
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
