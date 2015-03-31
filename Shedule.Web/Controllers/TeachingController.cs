using Shedule.Business;
using Shedule.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shedule.Web.Controllers
{
    public class TeachingController : Controller
    {
        // GET: Teaching
        public ActionResult Index()
        {
            List<Teaching> list = new List<Teaching>();
            using(BusinessContext businessContext = new BusinessContext())
            {
                list = businessContext.
            }
            

            return View();
        }
    }
}