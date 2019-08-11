using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVBuilder.Controllers
{
    public class CurriculumController : Controller
    {
        // GET: Curriculum
        public ActionResult Build()
        {
            return View();
        }
    }
}