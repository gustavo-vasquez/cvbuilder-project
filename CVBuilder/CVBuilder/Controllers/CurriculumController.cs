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

            List<SummaryBlockDTO> studiesDto = _curriculumServices.Studies.GetAllBlocks();

            foreach (SummaryBlockDTO block in studiesDto)
            {
                model.StudyBlocks.Add(new SummaryBlockViewModel()
                {
                    SummaryId = block.SummaryId,
                    Title = block.Title,
                    StateInTime = block.StateInTime
                });
            }

            List<SummaryBlockDTO> certificatesDto = _curriculumServices.Certificates.GetAllBlocks();

            foreach (SummaryBlockDTO block in certificatesDto)
            {
                model.CertificateBlocks.Add(new SummaryBlockViewModel()
                {
                    SummaryId = block.SummaryId,
                    Title = block.Title,
                    StateInTime = block.StateInTime
                });
            }

            List<SummaryBlockDTO> workExperiencesDto = _curriculumServices.WorkExperiences.GetAllBlocks();

            foreach (SummaryBlockDTO block in workExperiencesDto)
            {
                model.WorkExperiencesBlocks.Add(new SummaryBlockViewModel()
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Certificates(CertificatesViewModel model)
        {
            if(!ModelState.IsValid) { }

            CertificatesDTO dto = Mapping.Mapper.Map<CertificatesViewModel, CertificatesDTO>(model);
            switch (model.Type)
            {
                case FormType.ADD: _curriculumServices.Certificates.Create(dto); break;
                case FormType.EDIT: _curriculumServices.Certificates.Update(dto); break;
                default: break;
            }

            return Json(new { formid = "#" + model.FormId, id = model.CertificateID, mode = Convert.ToInt32(model.Type) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WorkExperiences(WorkExperiencesViewModel model)
        {
            if(!ModelState.IsValid) { }

            WorkExperiencesDTO dto = Mapping.Mapper.Map<WorkExperiencesViewModel, WorkExperiencesDTO>(model);
            switch (model.Type)
            {
                case FormType.ADD: _curriculumServices.WorkExperiences.Create(dto); break;
                case FormType.EDIT: _curriculumServices.WorkExperiences.Update(dto); break;
                default: break;
            }

            return Json(new { formid = "#" + model.FormId, id = model.WorkExperienceID, mode = Convert.ToInt32(model.Type) });
        }

        [HttpGet]
        public PartialViewResult GetSectionForm(string section)
        {
            ISectionViewModel model = null; string viewName = "";

            switch (section)
            {
                case SectionIds.Studies:
                    model = new StudiesViewModel();
                    viewName = "_StudiesForm";
                    break;
                case SectionIds.Certificates:
                    model = new CertificatesViewModel();
                    viewName = "_CertificatesForm";
                    break;
                case SectionIds.WorkExperiences:
                    model = new WorkExperiencesViewModel();
                    viewName = "_WorkExperiencesForm";
                    break;
                default:
                    throw new ArgumentException("La sección no existe.");
            }

            return PartialView(viewName, model);
        }

        [HttpGet]
        public PartialViewResult EditSectionForm(string section, int id)
        {
            ISectionViewModel model; string viewName = "";

            switch (section)
            {
                case SectionIds.Studies:
                    model = Mapping.Mapper.Map<StudiesDTO, StudiesViewModel>(_curriculumServices.Studies.GetById(id));
                    viewName = "_StudiesForm";
                    break;
                case SectionIds.Certificates:
                    model = Mapping.Mapper.Map<CertificatesDTO, CertificatesViewModel>(_curriculumServices.Certificates.GetById(id));
                    viewName = "_CertificatesForm";
                    break;
                case SectionIds.WorkExperiences:
                    model = Mapping.Mapper.Map<WorkExperiencesDTO, WorkExperiencesViewModel>(_curriculumServices.WorkExperiences.GetById(id));
                    viewName = "_WorkExperiencesForm";
                    break;
                default:
                    throw new ArgumentException("La sección no existe.");
            }

            return PartialView(viewName, model);
        }

        [HttpGet]
        public PartialViewResult GetSectionBlock(string section, int id)
        {
            SummaryBlockDTO dto; SummaryBlockViewModel model;

            switch (section)
            {
                case SectionIds.Studies:
                    dto = _curriculumServices.Studies.GetSummaryBlock(id);
                    model = Mapping.Mapper.Map<SummaryBlockDTO, SummaryBlockViewModel>(dto);
                    break;
                case SectionIds.Certificates:
                    dto = _curriculumServices.Certificates.GetSummaryBlock(id);
                    model = Mapping.Mapper.Map<SummaryBlockDTO, SummaryBlockViewModel>(dto);
                    break;
                case SectionIds.WorkExperiences:
                    dto = _curriculumServices.WorkExperiences.GetSummaryBlock(id);
                    model = Mapping.Mapper.Map<SummaryBlockDTO, SummaryBlockViewModel>(dto);
                    break;
                default:
                    throw new ArgumentException("La sección no existe.");
            }

            return PartialView("_StudyBlock", model);
        }

        [HttpPost]
        public void RemoveBlock(string section, int id)
        {
            switch (section)
            {
                case SectionIds.Studies:
                    _curriculumServices.Studies.Delete(id);
                    break;
                case SectionIds.Certificates:
                    _curriculumServices.Certificates.Delete(id);
                    break;
                case SectionIds.WorkExperiences:
                    _curriculumServices.WorkExperiences.Delete(id);
                    break;
                default:
                    throw new ArgumentException("La sección no existe.");
            }
        }
    }
}