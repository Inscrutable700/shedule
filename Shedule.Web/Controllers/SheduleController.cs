using Shedule.Business;
using Shedule.Data.Model;
using Shedule.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shedule.Web.Controllers
{
    public class SheduleController : Controller
    {
        // GET: Shedule
        public ActionResult Index()
        {


            return View();
        }

        [HttpPost]
        //[Authorize(Roles="admin")]
        public ActionResult AddLesson(LessonViewModel model)
        {
            Lesson lesson = null;
            using (BusinessContext businessContext = new BusinessContext())
            {
                lesson = businessContext.LessonManager.Add(
                    model.TeachingId,
                    model.PeriodNumber,
                    model.BeginDate,
                    model.Count,
                    model.TeacherId);
            }

            return View("Lesson", "Shedule", new { lessonId = lesson.Id});
        }

        public ActionResult Lesson(int lessonId)
        {
            
            return View();
        }

        public ActionResult ListTeaching()
        {
            
        }
    }
}