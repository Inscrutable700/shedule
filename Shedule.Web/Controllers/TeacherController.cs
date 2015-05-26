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
    [Authorize]
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            TeacherListViewModel model = new TeacherListViewModel();

            using (BusinessContext businessContext = new BusinessContext())
            {
                Teacher[] teachers = businessContext.TeacherManager.All();
                foreach (Teacher teacher in teachers)
                {
                    model.Teachers.Add(new TeacherListViewModel.TeacherItemViewModel()
                    {
                        FirstName = teacher.FirstName,
                        LastName = teacher.LasName,
                        Id = teacher.Id,
                    });
                }
            }

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NewTeacherViewModel model)
        {
            using (BusinessContext businessContext = new BusinessContext())
            {
                businessContext.TeacherManager.Add(
                    model.FirstName,
                    model.LastName,
                    model.MiddleName,
                    model.Description,
                    model.Degree,
                    model.Birthday);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int teacherId)
        {
            TeacherViewModel model = null;
            using (BusinessContext businessContext = new BusinessContext())
            {
                Teacher teacher = businessContext.TeacherManager.Get(teacherId);
                model = new TeacherViewModel()
                {
                    Birthday = teacher.Birthday,
                    Degree = teacher.Degree,
                    Description = teacher.Description,
                    FirstName = teacher.FirstName,
                    LasName = teacher.LasName,
                    MiddleName = teacher.MiddleName,
                    Id = teacher.Id,
                };
            }

            return View(model);
        }

        public ActionResult AddLesson(int teacherId, int lessonId)
        {
            using (BusinessContext businessContext = new BusinessContext())
            {
                businessContext.TeacherManager.AddLesson(teacherId, lessonId);
            }

            return RedirectToAction("Details", new { teacherId = teacherId});
        }
    }
}