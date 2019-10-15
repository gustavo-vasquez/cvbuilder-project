using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data
{
    public class TemplatesDL : DataLayerBase
    {
        public Templates GetByUserId(int userId)
        {
            Templates template = (from tem in _db.Context.Templates
                                join cv in _db.Context.Curriculum
                                on tem.TemplateID equals cv.ID_Template
                                where cv.ID_User == userId
                                select tem).SingleOrDefault();

            if (template != null)
                return template;
            else
                return _db.Context.Templates.Find(1);
        }

        public string GetPreviewPath(int userId)
        {   
            return GetByUserId(userId).PreviewPath;
        }

        public void ChangeTemplate(string path, int curriculumId, int userId)
        {
            Templates template = _db.Context.Templates.SingleOrDefault(t => t.PreviewPath == path);

            if (template != null)
            {
                Curriculum curriculum = _db.Context.Curriculum.Single(c => c.CurriculumID == curriculumId && c.ID_User == userId);
                curriculum.ID_Template = template.TemplateID;
                _db.Context.SaveChanges();
            }
        }
    }
}
