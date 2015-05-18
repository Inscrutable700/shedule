using Shedule.Business;
using Shedule.Data.Model;
using Shedule.Web.Models;
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
        // GET: all shedule
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SheduleForTeaching(int teachingId)
        {
            SheduleForTeachingViewModel model = new SheduleForTeachingViewModel();
            
            using (BusinessContext businessContext = new BusinessContext())
            {
                var teaching = businessContext.TeachingManager.Get(teachingId);
                model.TeachingName = teaching.Name;
                model.TeachingId = teaching.Id;
                
                foreach (var lesson in teaching.Lessons)
                {
                    model.Days[lesson.DayNumber].Lessons.Add(new SheduleDayViewModel.LessonViewModel()
                    {
                        Id = lesson.Id,
                        Name = lesson.Teaching.Name,
                    });
                }
            }

            return View(model);
        }

        public ActionResult SheduleForDay(int dayNumber)
        {
            SheduleForDayViewModel model = new SheduleForDayViewModel();

            using (BusinessContext businessContext = new BusinessContext())
            {
                var lessons = businessContext.LessonManager.AllForDay(dayNumber);
                var groupedLessons = lessons.GroupBy(l => l.Classroom.Name).ToList();
                model.DayOfWeek = dayNumber;
                foreach(var group in groupedLessons)
                {
                    List<SheduleForDayViewModel.LessonViewModel> list = new List<SheduleForDayViewModel.LessonViewModel>();
                    
                    foreach (var lesson in group)
                    {
                        SheduleForDayViewModel.LessonViewModel lessonViewModel = new SheduleForDayViewModel.LessonViewModel()
                        {
                            Name = lesson.Teaching.Name,
                            Id = lesson.Id,
                        };
                        list.Add(lessonViewModel);
                    }

                    model.Lessons.Add(group.Key, list);
                }
            }

            return View(model);
        }
    }
}