using CVBuilder.Data;
using CVBuilder.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services
{
    public class StudiesSL
    {
        private StudiesDL _dataLayer = new StudiesDL();

        public int Create(StudiesDTO dto)
        {
            Studies data = new Studies();
            data.Title = dto.Title;
            data.Institute = dto.Institute;
            data.City = dto.City;
            data.StartMonth = dto.StartMonth;
            data.StartYear = dto.StartYear;
            data.EndMonth = dto.EndMonth;
            data.EndYear = dto.EndYear;
            data.Description = dto.Description;
            data.IsVisible = dto.IsVisible;
            data.ID_Curriculum = 1;

            return _dataLayer.Create(data);
        }
    }
}
