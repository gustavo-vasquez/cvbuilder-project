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
        private PersonalDetailsSL serviceLayer = new PersonalDetailsSL();

        // GET: Curriculum
        [HttpGet]
        public ActionResult Build(string section)
        {
            return View(new BuildViewModel());
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

            int rowsAffected = serviceLayer.Create(dto);
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

            int rowsAffected = serviceLayer.Create(dto);
            if (rowsAffected > 0)
                return RedirectToAction("Index", "Home");
            else
                return RedirectToAction("SignIn", "Account");
        }
    }
}