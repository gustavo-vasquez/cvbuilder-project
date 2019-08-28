﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data
{
    public class StudiesDL
    {
        private IDatabaseConnection _db = new DatabaseConnection();

        public int Create(Studies data)
        {
            int result = _db.Context.usp_Studies_Create(
                    data.Title,
                    data.Institute,
                    data.City,
                    data.StartMonth,
                    data.StartYear,
                    data.EndMonth,
                    data.EndYear,
                    data.Description,
                    data.IsVisible,
                    data.ID_Curriculum
                );

            return result;
        }
    }
}
