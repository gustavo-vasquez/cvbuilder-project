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
        private PersonalDetailsSL _personalDetailsService = new PersonalDetailsSL();
        private StudiesSL _studiesService = new StudiesSL();

        // GET: Curriculum
        [HttpGet]
        public ActionResult Build(string section)
        {
            BuildViewModel model = new BuildViewModel();
            List<SummaryBlockDTO> studiesDto = _studiesService.GetStudyBlocks();

            foreach(SummaryBlockDTO block in studiesDto)
            {
                model.StudyBlocks.Add(new SummaryBlockViewModel()
                {
                    SummaryId = block.SummaryId,
                    Title = block.Title,
                    StateInTime = block.StateInTime
                });
            }

            PersonalDetailsDTO personalDetailsDto = _personalDetailsService.GetPersonalDetailsByCurriculumId(1);
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
            model.PersonalDetails.Address = personalDetailsDto.Address;
            model.PersonalDetails.City = personalDetailsDto.City;
            model.PersonalDetails.PostalCode = personalDetailsDto.PostalCode;
            //model.PersonalDetails.BirthDate = personalDetailsDto.BirthDate;
            model.PersonalDetails.IdentityCard = personalDetailsDto.IdentityCard;
            model.PersonalDetails.Country = personalDetailsDto.Country;
            model.PersonalDetails.WebPageUrl = personalDetailsDto.WebPageUrl;
            model.PersonalDetails.LinkedInUrl = personalDetailsDto.LinkedInUrl;
            model.PersonalDetails.GithubUrl = personalDetailsDto.GithubUrl;
            model.PersonalDetails.FacebookUrl = personalDetailsDto.FacebookUrl;
            model.PersonalDetails.TwitterUrl = personalDetailsDto.TwitterUrl;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Build(BuildViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            PersonalDetailsDTO dto = new PersonalDetailsDTO();
            dto.Name = model.PersonalDetails.Name;
            dto.LastName = model.PersonalDetails.LastName;
            dto.Email = model.PersonalDetails.Email;
            dto.City = model.PersonalDetails.City;
            dto.Summary = model.PersonalDetails.Summary;
            dto.SummaryIsVisible = true;

            int rowsAffected = _personalDetailsService.Create(dto);
            if (rowsAffected > 0)
                return RedirectToAction("Index", "Home");
            else
                return RedirectToAction("SignIn", "Account");
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

            PersonalDetailsDTO dto = new PersonalDetailsDTO();
            dto.Name = model.Name;
            dto.LastName = model.LastName;
            dto.Email = model.Email;
            dto.City = model.City;
            dto.Summary = model.Summary;
            dto.SummaryIsVisible = true;

            if (_personalDetailsService.Create(dto) > 0)
                return RedirectToAction("Index", "Home");
            else
                return RedirectToAction("SignIn", "Account");
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
                case FormType.ADD: _studiesService.Create(dto); break;
                case FormType.EDIT: _studiesService.Update(dto); break;
                default: break;
            }

            return Json(new { formid = "#" + model.FormId, id = model.StudyID, mode = Convert.ToInt32(model.Type) }, JsonRequestBehavior.AllowGet);
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
            StudiesDTO dto = _studiesService.GetStudyById(id);
            StudiesViewModel model = Mapping.Mapper.Map<StudiesDTO, StudiesViewModel>(dto);

            return PartialView("_StudiesForm", model);
        }

        [HttpGet]
        public PartialViewResult GetSectionBlock(string section, int id)
        {
            SummaryBlockDTO dto = _studiesService.GetSummaryBlock(id);
            SummaryBlockViewModel model = new SummaryBlockViewModel();
            model.SummaryId = dto.SummaryId;
            model.Title = dto.Title;
            model.StateInTime = dto.StateInTime;

            return PartialView("_StudyBlock", model);
        }

        [HttpPost]
        public void RemoveBlock(int id)
        {
            _studiesService.Remove(id);
        }
    }
}