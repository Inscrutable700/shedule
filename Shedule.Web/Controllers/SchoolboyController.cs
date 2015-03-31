using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shedule.Web.ViewModels;
using Shedule.Business;
using Shedule.Data.Model;

namespace Shedule.Web.Controllers
{
    public class SchoolboyController : Controller
    {
        public SchoolboyController()
        {
            
        }

        // GET: Schoolboy
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SchoolBoyById(int id)
        {
            SchoolboyViewModel model = new SchoolboyViewModel();

            return View(model);
        }

        public ActionResult Add(SchoolboyViewModel model)
        {
            using (BusinessContext businessContext = new BusinessContext())
            {
                Schoolboy schoolboy = new Schoolboy()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age
                };
                businessContext.SchoolboyManager.Add(schoolboy);
            }
            
            return this.View();
        }
    }
}