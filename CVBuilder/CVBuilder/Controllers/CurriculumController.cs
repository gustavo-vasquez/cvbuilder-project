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
            List<SummaryBlockDTO> dto = _studiesService.GetStudyBlocks();

            foreach(SummaryBlockDTO block in dto)
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
        public void Studies(StudiesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //BuildViewModel fullModel = new BuildViewModel();
                //return PartialView("_StudiesForm", model);
            }

            StudiesDTO dto = new StudiesDTO();
            dto.Title = model.Title;
            dto.Institute = model.Institute;
            dto.City = model.City;
            dto.StartMonth = model.StartMonth;
            dto.StartYear = model.StartYear;
            dto.EndMonth = model.EndMonth;
            dto.EndYear = model.EndYear;
            dto.Description = model.Description;
            dto.IsVisible = true;

            _studiesService.Create(dto);
        }

        [HttpGet]
        public PartialViewResult GetSectionForm()
        {
            return PartialView("_StudiesForm", new StudiesViewModel());
        }

        //[HttpGet]
        //public PartialViewResult GetSectionBlock(string area)
        //{
        //    List<StudiesDTO> dto = _studiesService.GetAllStudies();
        //    List<StudiesViewModel> model = new List<StudiesViewModel>();

        //    foreach (StudiesDTO study in dto)
        //    {
        //        model.Add(new StudiesViewModel()
        //        {
        //            Title = study.Title,
        //            Institute = study.Institute,
        //            City = study.City,
        //            StartMonth = study.StartMonth,
        //            StartYear = study.StartYear,
        //            EndMonth = study.EndMonth,
        //            EndYear = study.EndYear,
        //            Description = study.Description,
        //            IsVisible = study.IsVisible
        //        });
        //    }

        //    return PartialView("_StudiesBlocks", model);
        //}

        [HttpGet]
        public PartialViewResult GetSectionBlock(string area)
        {
            SummaryBlockDTO dto = _studiesService.GetSummaryBlock();
            SummaryBlockViewModel model = new SummaryBlockViewModel();
            model.SummaryId = dto.SummaryId;
            model.Title = dto.Title;
            model.StateInTime = dto.StateInTime;

            return PartialView("_StudyBlock", model);
        }
    }
}