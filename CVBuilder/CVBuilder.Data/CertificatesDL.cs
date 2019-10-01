﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data
{
    public class CertificatesDL : DataLayerBase, ICurriculumDL<Certificates>
    {
        public int Create(Certificates data)
        {
            int result = _db.Context.usp_Certificates_Create(
                    data.Name,
                    data.Institute,
                    data.OnlineMode,
                    data.InProgress,
                    data.Year,
                    data.Description,
                    data.IsVisible,
                    data.ID_Curriculum
                );

            return result;
        }

        public void Update(Certificates data)
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
                    data.ID_Curriculum
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

        public IQueryable<Certificates> GetAll()
        {
            return _db.Context.Certificates.Where(c => c.ID_Curriculum == 1);
        }
    }
}
