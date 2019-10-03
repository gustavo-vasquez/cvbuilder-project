﻿using CVBuilder.Common;
using CVBuilder.Data;
using CVBuilder.Services.automapper;
using CVBuilder.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services
{
    public class SkillsSL : ICurriculumServices<SkillsDTO>
    {
        private SkillsDL _dataLayer = new SkillsDL();

        public int Create(SkillsDTO dto)
        {
            Skills data = Mapping.Mapper.Map<SkillsDTO, Skills>(dto);
            return _dataLayer.Create(data);
        }

        public void Update(SkillsDTO dto)
        {
            _dataLayer.Update(Mapping.Mapper.Map<SkillsDTO, Skills>(dto));
        }

        public int Delete(int id)
        {
            return _dataLayer.Delete(id);
        }

        public SkillsDTO GetById(int id)
        {
            Skills data = _dataLayer.GetById(id);
            return Mapping.Mapper.Map<Skills, SkillsDTO>(data);
        }

        public List<SummaryBlockDTO> GetAllBlocks()
        {
            IQueryable<Skills> allSkills = _dataLayer.GetAll();
            List<SummaryBlockDTO> skillBlocks = new List<SummaryBlockDTO>();

            foreach (Skills skill in allSkills)
            {
                skillBlocks.Add(new SummaryBlockDTO()
                {
                    SummaryId = skill.SkillID,
                    Title = skill.Name,
                    StateInTime = "(" + LevelOptions.LevelComboBox[skill.Level] + ")"
                });
            }

            return skillBlocks;
        }

        public SummaryBlockDTO GetSummaryBlock(int id)
        {
            Skills skill;
            if (id > 0)
                skill = _dataLayer.GetById(id);
            else
                skill = _dataLayer.GetLast();

            return new SummaryBlockDTO()
            {
                SummaryId = skill.SkillID,
                Title = skill.Name,
                StateInTime = "(" + LevelOptions.LevelComboBox[skill.Level] + ")"
            };
        }
    }
}
