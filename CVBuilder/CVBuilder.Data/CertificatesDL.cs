using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data
{
    public class CertificatesDL : DataLayerBase, ICurriculumData<Certificates>
    {
        public int Create(Certificates data, int curriculumId)
        {
            int result = _db.Context.usp_Certificates_Create(
                    data.Name,
                    data.Institute,
                    data.OnlineMode,
                    data.InProgress,
                    data.Year,
                    data.Description,
                    data.IsVisible,
                    curriculumId
                );

            return result;
        }

        public void Update(Certificates data, int curriculumId)
        {
            _db.Context.usp_Certificates_Update(
                    data.CertificateID,
                    data.Name,
                    data.Institute,
                    data.OnlineMode,
                    data.InProgress,
                    data.Year,
                    data.Description,
                    data.IsVisible,
                    curriculumId
                );
        }

        public int Delete(int id)
        {
            int result = _db.Context.usp_Certificates_Delete(id);
            return result;
        }

        public Certificates GetById(int id)
        {
            return _db.Context.Certificates.Find(id);
        }

        public Certificates GetLast()
        {
            return _db.Context.Certificates.OrderByDescending(c => c.CertificateID).First();
        }

        public IQueryable<Certificates> GetAll(int curriculumId)
        {
            return _db.Context.Certificates.Where(c => c.ID_Curriculum == curriculumId);
        }

        public IQueryable<Certificates> GetAllVisible(int curriculumId)
        {
            return _db.Context.Certificates.Where(s => s.ID_Curriculum == curriculumId && s.IsVisible);
        }

        public void ToggleVisibility(int curriculumId)
        {
            Curriculum curriculum = _db.Context.Curriculum.SingleOrDefault(c => c.CurriculumID == curriculumId);
            curriculum.CertificatesIsVisible = curriculum.CertificatesIsVisible == true ? false : true;
            _db.Context.SaveChanges();
        }
    }
}
