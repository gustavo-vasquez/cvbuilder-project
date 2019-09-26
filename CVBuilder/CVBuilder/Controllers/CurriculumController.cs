using AutoMapper;
using CVBuilder.automapper;
using CVBuilder.enums;
using CVBuilder.Services;
using CVBuilder.Services.DTOs;
using CVBuilder.ViewModels.Curriculum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVBuilder.Controllers
{
    public class CurriculumController : Controller
    {
        private CurriculumSL _curriculumServices = new CurriculumSL();

        // GET: Curriculum
        [HttpGet]
        public ActionResult Build(string section)
        {
            BuildViewModel model = new BuildViewModel();

            PersonalDetailsDTO personalDetailsDto = _curriculumServices.PersonalDetails.GetPersonalDetailsByCurriculumId(1);

            if (personalDetailsDto != null)
            {
                model.PersonalDetails.PersonalDetailsID = personalDetailsDto.PersonalDetailsID;
                model.PersonalDetails.Type = FormType.EDIT;

                model.PersonalDetails.Name = personalDetailsDto.Name;
                model.PersonalDetails.LastName = personalDetailsDto.LastName;
                model.PersonalDetails.Photo = personalDetailsDto.Photo;
                model.PersonalDetails.Summary = personalDetailsDto.Summary;
                model.PersonalDetails.SummaryCustomTitle = personalDetailsDto.SummaryCustomTitle;
                model.PersonalDetails.SummaryIsVisible = personalDetailsDto.SummaryIsVisible;
                model.PersonalDetails.Email = personalDetailsDto.Email;
                model.PersonalDetails.LinePhone = personalDetailsDto.LinePhone;
                model.PersonalDetails.AreaCodeLP = personalDetailsDto.AreaCodeLP;
                model.PersonalDetails.MobilePhone = personalDetailsDto.MobilePhone;
                model.PersonalDetails.AreaCodeMP = personalDetailsDto.AreaCodeMP;
                model.PersonalDetails.Day = personalDetailsDto.Day;
                model.PersonalDetails.Month = personalDetailsDto.Month;
                model.PersonalDetails.Year = personalDetailsDto.Year;
                model.PersonalDetails.Address = personalDetailsDto.Address;
                model.PersonalDetails.City = personalDetailsDto.City;
                model.PersonalDetails.PostalCode = personalDetailsDto.PostalCode;
                model.PersonalDetails.IdentityCard = personalDetailsDto.IdentityCard;
                model.PersonalDetails.Country = personalDetailsDto.Country;
                model.PersonalDetails.WebPageUrl = personalDetailsDto.WebPageUrl;
                model.PersonalDetails.LinkedInUrl = personalDetailsDto.LinkedInUrl;
                model.PersonalDetails.GithubUrl = personalDetailsDto.GithubUrl;
                model.PersonalDetails.FacebookUrl = personalDetailsDto.FacebookUrl;
                model.PersonalDetails.TwitterUrl = personalDetailsDto.TwitterUrl;
            }

            List<SummaryBlockDTO> studiesDto = _curriculumServices.Studies.GetStudyBlocks();

            foreach(SummaryBlockDTO block in studiesDto)
            {
                model.StudyBlocks.Add(new SummaryBlockViewModel()
                {
                    SummaryId = block.SummaryId,
                    Title = block.Title,
                    StateInTime = block.StateInTime
                });
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PersonalDetails(PersonalDetailsViewModel model)
        {
            if(!ModelState.IsValid)
            {
                BuildViewModel fullModel = new BuildViewModel();
                fullModel.PersonalDetails = model;
                return View("Build", fullModel);
            }

            PersonalDetailsDTO dto = Mapping.Mapper.Map<PersonalDetailsViewModel, PersonalDetailsDTO>(model);
            //PersonalDetailsDTO dto = new PersonalDetailsDTO();
            //dto.Name = model.Name;
            //dto.LastName = model.LastName;
            //dto.Email = model.Email;
            //dto.City = model.City;
            //dto.Summary = model.Summary;
            //dto.SummaryIsVisible = true;

            switch (model.Type)
            {
                case FormType.ADD: _curriculumServices.PersonalDetails.Create(dto); break;
                case FormType.EDIT: _curriculumServices.PersonalDetails.Update(dto); break;
                default: break;
            }

            return Json(new { formid = "#" + model.FormId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Studies(StudiesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //BuildViewModel fullModel = new BuildViewModel();
                //return PartialView("_StudiesForm");
            }
            
            StudiesDTO dto = Mapping.Mapper.Map<StudiesViewModel, StudiesDTO>(model);
            switch (model.Type)
            {
                case FormType.ADD: _curriculumServices.Studies.Create(dto); break;
                case FormType.EDIT: _curriculumServices.Studies.Update(dto); break;
                default: break;
            }

            return Json(new { formid = "#" + model.FormId, id = model.StudyID, mode = Convert.ToInt32(model.Type) });
        }

        [HttpGet]
        public PartialViewResult GetSectionForm(string section)
        {
            StudiesViewModel model = new StudiesViewModel();
            return PartialView("_StudiesForm", model);
        }

        [HttpGet]
        public PartialViewResult EditSectionForm(string section, int id)
        {
            StudiesDTO dto = _curriculumServices.Studies.GetStudyById(id);
            StudiesViewModel model = Mapping.Mapper.Map<StudiesDTO, StudiesViewModel>(dto);

            return PartialView("_StudiesForm", model);
        }

        [HttpGet]
        public PartialViewResult GetSectionBlock(string section, int id)
        {
            SummaryBlockDTO dto = _curriculumServices.Studies.GetSummaryBlock(id);
            SummaryBlockViewModel model = Mapping.Mapper.Map<SummaryBlockDTO, SummaryBlockViewModel>(dto);
            //SummaryBlockViewModel model = new SummaryBlockViewModel();
            //model.SummaryId = dto.SummaryId;
            //model.Title = dto.Title;
            //model.StateInTime = dto.StateInTime;

            return PartialView("_StudyBlock", model);
        }

        [HttpPost]
        public void RemoveBlock(int id)
        {
            _curriculumServices.Studies.Remove(id);
        }
    }
}