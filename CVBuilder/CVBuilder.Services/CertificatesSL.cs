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
    public class CertificatesSL : ICurriculumSL<CertificatesDTO>
    {
        private CertificatesDL _dataLayer = new CertificatesDL();

        public int Create(CertificatesDTO dto)
        {
            Certificates data = Mapping.Mapper.Map<CertificatesDTO, Certificates>(dto);
            return _dataLayer.Create(data);
        }

        public void Update(CertificatesDTO dto)
        {
            _dataLayer.Update(Mapping.Mapper.Map<CertificatesDTO, Certificates>(dto));
        }

        public int Delete(int id)
        {
            return _dataLayer.Delete(id);
        }

        public List<CertificatesDTO> GetAll()
        {
            IQueryable<Certificates> allCertificates = _dataLayer.GetAll();
            List<CertificatesDTO> dto = new List<CertificatesDTO>();

            foreach (Certificates certificate in allCertificates)
            {
                dto.Add(new CertificatesDTO()
                {
                    Name = certificate.Name,
                    Institute = certificate.Institute,
                    OnlineMode = certificate.OnlineMode,
                    InProgress = certificate.InProgress,
                    Year = certificate.Year
                });
            }

            return dto;
        }

        public CertificatesDTO GetById(int id)
        {
            Certificates data = _dataLayer.GetById(id);
            return Mapping.Mapper.Map<Certificates, CertificatesDTO>(data);
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
                StateInTime = (certificate.InProgress) ? "(En progreso)" : "(" + certificate.Year.ToString() + ")"
            };
        }

        public List<SummaryBlockDTO> GetAllBlocks()
        {
            IQueryable<Certificates> allCertificates = _dataLayer.GetAll();
            List<SummaryBlockDTO> certificateBlocks = new List<SummaryBlockDTO>();

            foreach (Certificates certificate in allCertificates)
            {
                certificateBlocks.Add(new SummaryBlockDTO()
                {
                    SummaryId = certificate.CertificateID,
                    Title = certificate.Name,
                    StateInTime = (certificate.InProgress) ? "(En progreso)" : "(" + certificate.Year.ToString() + ")"
                });
            }

            return certificateBlocks;
        }
    }
}
