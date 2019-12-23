using CVBuilder.Common;
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
    public class CertificatesSL : ICurriculumServices<CertificatesDTO>
    {
        private CertificatesDL _dataLayer = new CertificatesDL();

        public int Create(CertificatesDTO dto, int curriculumId)
        {
            Certificates data = Mapping.Mapper.Map<CertificatesDTO, Certificates>(dto);
            return _dataLayer.Create(data, curriculumId);
        }

        public void Update(CertificatesDTO dto, int curriculumId)
        {
            _dataLayer.Update(Mapping.Mapper.Map<CertificatesDTO, Certificates>(dto), curriculumId);
        }

        public int Delete(int id)
        {
            return _dataLayer.Delete(id);
        }

        public CertificatesDTO GetById(int id)
        {
            Certificates data = _dataLayer.GetById(id);
            return Mapping.Mapper.Map<Certificates, CertificatesDTO>(data);
        }

        public List<CertificatesDTO> GetAll(int curriculumId)
        {
            return Mapping.Mapper.Map<List<Certificates>, List<CertificatesDTO>>(_dataLayer.GetAll(curriculumId).ToList());
        }

        public List<CertificatesDTO> GetAllVisible(int curriculumId)
        {
            return Mapping.Mapper.Map<List<Certificates>, List<CertificatesDTO>>(_dataLayer.GetAllVisible(curriculumId).ToList());
        }

        public SummaryBlockDTO GetSummaryBlock(int id)
        {
            Certificates certificate;
            if (id > 0)
                certificate = _dataLayer.GetById(id);
            else
                certificate = _dataLayer.GetLast();

            return new SummaryBlockDTO()
            {
                SummaryId = certificate.CertificateID,
                Title = certificate.Name,
                StateInTime = (certificate.InProgress) ? "(" + CurriculumGlobals.CERTIFICATE_INPROGRESS_TEXT + ")" : "(" + certificate.Year.ToString() + ")",
                IsVisible = certificate.IsVisible
            };
        }

        public List<SummaryBlockDTO> GetAllBlocks(int curriculumId)
        {
            IQueryable<Certificates> allCertificates = _dataLayer.GetAll(curriculumId);
            List<SummaryBlockDTO> certificateBlocks = new List<SummaryBlockDTO>();

            foreach (Certificates certificate in allCertificates)
            {
                certificateBlocks.Add(new SummaryBlockDTO()
                {
                    SummaryId = certificate.CertificateID,
                    Title = certificate.Name,
                    StateInTime = (certificate.InProgress) ? "(" + CurriculumGlobals.CERTIFICATE_INPROGRESS_TEXT + ")" : "(" + certificate.Year.ToString() + ")",
                    IsVisible = certificate.IsVisible
                });
            }

            return certificateBlocks;
        }

        public void ToggleVisibility(int curriculumId)
        {
            _dataLayer.ToggleVisibility(curriculumId);
        }
    }
}
