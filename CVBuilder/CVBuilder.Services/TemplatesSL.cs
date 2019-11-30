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
    public class TemplatesSL
    {
        private TemplatesDL _dataLayer = new TemplatesDL();

        public TemplatesDTO GetByUserId(string userId)
        {
            Templates data = _dataLayer.GetByUserId(userId);
            return Mapping.Mapper.Map<Templates, TemplatesDTO>(data);
        }

        public string GetPreviewPath(string userId)
        {
            return _dataLayer.GetPreviewPath(userId);
        }

        public void ChangeTemplate(string path, int curriculumId, string userId)
        {
            _dataLayer.ChangeTemplate(path, curriculumId, userId);
        }
    }
}
