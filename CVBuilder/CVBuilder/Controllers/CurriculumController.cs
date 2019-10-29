using AutoMapper;
using CVBuilder.automapper;
using CVBuilder.enums;
using CVBuilder.Services;
using CVBuilder.Services.DTOs;
using CVBuilder.ViewModels.Curriculum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVBuilder.Controllers
{
    public class CurriculumController : Controller
    {
        private CurriculumSL _curriculumServices = new CurriculumSL();
        private const string _sectionErrorMessage = "La sección no existe.";

        // GET: Curriculum
        [HttpGet]
        public ActionResult Build(string section)
        {
            BuildViewModel model = new BuildViewModel();
            PersonalDetailsDTO personalDetailsDto = _curriculumServices.PersonalDetails.GetPersonalDetailsByCurriculumId(1);

            if (personalDetailsDto != null)
                model.PersonalDetails = Mapping.Mapper.Map<PersonalDetailsDTO, PersonalDetailsViewModel>(personalDetailsDto);
            
            model.StudyBlocks = Mapping.Mapper.Map<List<SummaryBlockDTO>, List<SummaryBlockViewModel>>(_curriculumServices.Studies.GetAllBlocks());
            model.CertificateBlocks = Mapping.Mapper.Map<List<SummaryBlockDTO>, List<SummaryBlockViewModel>>(_curriculumServices.Certificates.GetAllBlocks());
            model.WorkExperienceBlocks = Mapping.Mapper.Map<List<SummaryBlockDTO>, List<SummaryBlockViewModel>>(_curriculumServices.WorkExperiences.GetAllBlocks());
            model.LanguageBlocks = Mapping.Mapper.Map<List<SummaryBlockDTO>, List<SummaryBlockViewModel>>(_curriculumServices.Languages.GetAllBlocks());
            model.SkillBlocks = Mapping.Mapper.Map<List<SummaryBlockDTO>, List<SummaryBlockViewModel>>(_curriculumServices.Skills.GetAllBlocks());
            model.InterestBlocks = Mapping.Mapper.Map<List<SummaryBlockDTO>, List<SummaryBlockViewModel>>(_curriculumServices.Interests.GetAllBlocks());
            model.PersonalReferenceBlocks = Mapping.Mapper.Map<List<SummaryBlockDTO>, List<SummaryBlockViewModel>>(_curriculumServices.PersonalReferences.GetAllBlocks());
            model.CustomSectionBlocks = Mapping.Mapper.Map<List<SummaryBlockDTO>, List<SummaryBlockViewModel>>(_curriculumServices.CustomSections.GetAllBlocks());
            model.PreviewPath = _curriculumServices.Templates.GetPreviewPath(1);

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Languages(LanguagesViewModel model)
        {
            if (!ModelState.IsValid) { }

            LanguagesDTO dto = Mapping.Mapper.Map<LanguagesViewModel, LanguagesDTO>(model);
            switch (model.Type)
            {
                case FormType.ADD: _curriculumServices.Languages.Create(dto); break;
                case FormType.EDIT: _curriculumServices.Languages.Update(dto); break;
                default: break;
            }

            return Json(new { formid = "#" + model.FormId, id = model.LanguageID, mode = Convert.ToInt32(model.Type) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Skills(SkillsViewModel model)
        {
            if (!ModelState.IsValid) { }

            SkillsDTO dto = Mapping.Mapper.Map<SkillsViewModel, SkillsDTO>(model);
            switch (model.Type)
            {
                case FormType.ADD: _curriculumServices.Skills.Create(dto); break;
                case FormType.EDIT: _curriculumServices.Skills.Update(dto); break;
                default: break;
            }

            return Json(new { formid = "#" + model.FormId, id = model.SkillID, mode = Convert.ToInt32(model.Type) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Interests(InterestsViewModel model)
        {
            if (!ModelState.IsValid) { }

            InterestsDTO dto = Mapping.Mapper.Map<InterestsViewModel, InterestsDTO>(model);
            switch (model.Type)
            {
                case FormType.ADD: _curriculumServices.Interests.Create(dto); break;
                case FormType.EDIT: _curriculumServices.Interests.Update(dto); break;
                default: break;
            }

            return Json(new { formid = "#" + model.FormId, id = model.InterestID, mode = Convert.ToInt32(model.Type) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PersonalReferences(PersonalReferencesViewModel model)
        {
            if (!ModelState.IsValid) { }

            PersonalReferencesDTO dto = Mapping.Mapper.Map<PersonalReferencesViewModel, PersonalReferencesDTO>(model);
            switch (model.Type)
            {
                case FormType.ADD: _curriculumServices.PersonalReferences.Create(dto); break;
                case FormType.EDIT: _curriculumServices.PersonalReferences.Update(dto); break;
                default: break;
            }

            return Json(new { formid = "#" + model.FormId, id = model.PersonalReferenceID, mode = Convert.ToInt32(model.Type) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustomSections(CustomSectionsViewModel model)
        {
            if (!ModelState.IsValid) { }

            CustomSectionsDTO dto = Mapping.Mapper.Map<CustomSectionsViewModel, CustomSectionsDTO>(model);
            switch (model.Type)
            {
                case FormType.ADD: _curriculumServices.CustomSections.Create(dto); break;
                case FormType.EDIT: _curriculumServices.CustomSections.Update(dto); break;
                default: break;
            }

            return Json(new { formid = "#" + model.FormId, id = model.CustomSectionID, mode = Convert.ToInt32(model.Type) });
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
                case SectionIds.Languages:
                    model = new LanguagesViewModel();
                    viewName = "_LanguagesForm";
                    break;
                case SectionIds.Skills:
                    model = new SkillsViewModel();
                    viewName = "_SkillsForm";
                    break;
                case SectionIds.Interests:
                    model = new InterestsViewModel();
                    viewName = "_InterestsForm";
                    break;
                case SectionIds.PersonalReferences:
                    model = new PersonalReferencesViewModel();
                    viewName = "_PersonalReferencesForm";
                    break;
                case SectionIds.CustomSections:
                    model = new CustomSectionsViewModel();
                    viewName = "_CustomSectionsForm";
                    break;
                default:
                    throw new ArgumentException(_sectionErrorMessage);
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
                case SectionIds.Languages:
                    model = Mapping.Mapper.Map<LanguagesDTO, LanguagesViewModel>(_curriculumServices.Languages.GetById(id));
                    viewName = "_LanguagesForm";
                    break;
                case SectionIds.Skills:
                    model = Mapping.Mapper.Map<SkillsDTO, SkillsViewModel>(_curriculumServices.Skills.GetById(id));
                    viewName = "_SkillsForm";
                    break;
                case SectionIds.Interests:
                    model = Mapping.Mapper.Map<InterestsDTO, InterestsViewModel>(_curriculumServices.Interests.GetById(id));
                    viewName = "_InterestsForm";
                    break;
                case SectionIds.PersonalReferences:
                    model = Mapping.Mapper.Map<PersonalReferencesDTO, PersonalReferencesViewModel>(_curriculumServices.PersonalReferences.GetById(id));
                    viewName = "_PersonalReferencesForm";
                    break;
                case SectionIds.CustomSections:
                    model = Mapping.Mapper.Map<CustomSectionsDTO, CustomSectionsViewModel>(_curriculumServices.CustomSections.GetById(id));
                    viewName = "_CustomSectionsForm";
                    break;
                default:
                    throw new ArgumentException(_sectionErrorMessage);
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
                case SectionIds.Languages:
                    dto = _curriculumServices.Languages.GetSummaryBlock(id);
                    model = Mapping.Mapper.Map<SummaryBlockDTO, SummaryBlockViewModel>(dto);
                    break;
                case SectionIds.Skills:
                    dto = _curriculumServices.Skills.GetSummaryBlock(id);
                    model = Mapping.Mapper.Map<SummaryBlockDTO, SummaryBlockViewModel>(dto);
                    break;
                case SectionIds.Interests:
                    dto = _curriculumServices.Interests.GetSummaryBlock(id);
                    model = Mapping.Mapper.Map<SummaryBlockDTO, SummaryBlockViewModel>(dto);
                    break;
                case SectionIds.PersonalReferences:
                    dto = _curriculumServices.PersonalReferences.GetSummaryBlock(id);
                    model = Mapping.Mapper.Map<SummaryBlockDTO, SummaryBlockViewModel>(dto);
                    break;
                case SectionIds.CustomSections:
                    dto = _curriculumServices.CustomSections.GetSummaryBlock(id);
                    model = Mapping.Mapper.Map<SummaryBlockDTO, SummaryBlockViewModel>(dto);
                    break;
                default:
                    throw new ArgumentException(_sectionErrorMessage);
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
                case SectionIds.Languages:
                    _curriculumServices.Languages.Delete(id);
                    break;
                case SectionIds.Skills:
                    _curriculumServices.Skills.Delete(id);
                    break;
                case SectionIds.Interests:
                    _curriculumServices.Interests.Delete(id);
                    break;
                case SectionIds.PersonalReferences:
                    _curriculumServices.PersonalReferences.Delete(id);
                    break;
                case SectionIds.CustomSections:
                    _curriculumServices.CustomSections.Delete(id);
                    break;
                default:
                    throw new ArgumentException(_sectionErrorMessage);
            }
        }

        [HttpGet]
        public ActionResult Finished()
        {
            TemplatesDTO dto = _curriculumServices.Templates.GetByUserId(1);
            return View(Mapping.Mapper.Map<TemplatesDTO, FinishedViewModel>(dto));
        }

        [HttpGet]
        public void ChangeTemplate(string path)
        {
            _curriculumServices.Templates.ChangeTemplate(path, 1, 1);
        }
    }
}
