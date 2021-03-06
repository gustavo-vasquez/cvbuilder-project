﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data
{
    public class PersonalDetailsDL
    {
        private IDatabaseConnection _db = new DatabaseConnection();

        public int Create(PersonalDetails data, int curriculumId)
        {
            //string connectionString = @"data source=GUSTAVO-PC\SQLEXPRESS;initial catalog=CVBuilder;persist security info=True;user id=sa;password=123;MultipleActiveResultSets=True;App=EntityFramework"; //ConfigurationManager.ConnectionStrings["CVBuilderEntities"].ConnectionString;
            //SqlConnection connection = new SqlConnection(connectionString);
            //connection.Open();
            //SqlCommand command = new SqlCommand("usp.Curriculum_Create", connection);
            //command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.Add(new SqlParameter("@email", data.Email));
            //command.Parameters.Add(new SqlParameter("@name", data.Name));
            //command.Parameters.Add(new SqlParameter("@lastname", data.LastName));
            //return command.ExecuteNonQuery();
            int result = _db.Context.usp_PersonalDetails_Create(
                            data.Name,
                            data.LastName,
                            data.Email,
                            data.Profession,
                            data.Photo,
                            data.MimeType,
                            data.Address,
                            data.City,
                            data.PostalCode,
                            data.AreaCodeLP,
                            data.LinePhone,
                            data.AreaCodeMP,
                            data.MobilePhone,
                            data.Country,
                            data.Summary,
                            data.SummaryCustomTitle,
                            data.SummaryIsVisible,
                            data.WebPageUrl,
                            data.LinkedInUrl,
                            data.GithubUrl,
                            data.FacebookUrl,
                            data.TwitterUrl,
                            curriculumId
                    );
            
            return result;
        }

        public int Update(PersonalDetails data, int curriculumId)
        {
            int result = _db.Context.usp_PersonalDetails_Update(
                    data.PersonalDetailsID,
                    data.Name,
                    data.LastName,
                    data.Email,
                    data.Profession,
                    data.Photo,
                    data.MimeType,
                    data.Address,
                    data.City,
                    data.PostalCode,
                    data.AreaCodeLP,
                    data.LinePhone,
                    data.AreaCodeMP,
                    data.MobilePhone,
                    data.Country,
                    data.Summary,
                    data.SummaryCustomTitle,
                    data.SummaryIsVisible,
                    data.WebPageUrl,
                    data.LinkedInUrl,
                    data.GithubUrl,
                    data.FacebookUrl,
                    data.TwitterUrl,
                    curriculumId
                );

            return result;
        }

        public PersonalDetails GetPersonalDetailsByCurriculumId(int id)
        {
            return _db.Context.PersonalDetails.Where(p => p.ID_Curriculum == id).FirstOrDefault();
        }
    }
}
