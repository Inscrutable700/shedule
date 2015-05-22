using AutoMapper;
using Newtonsoft.Json;
using Shedule.Business;
using Shedule.Data.Model;
using Shedule.Web.Helpers;
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
        public SheduleController()
        {
        }

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
                    List<LessonItemViewModel> list = new List<LessonItemViewModel>();
                    
                    foreach (var lesson in group)
                    {
                        LessonItemViewModel lessonViewModel = new LessonItemViewModel()
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

        public ActionResult SheduleForSchoolboy(int schoolboyId)
        {
            var model = new SheduleForSchoolboy();
            using (BusinessContext businessContext = new BusinessContext())
            {
                var schoolboy = businessContext.LessonManager.SchoolboyWithLessons(schoolboyId);
                var groupedLessons = schoolboy.Lessons.GroupBy(l => l.Classroom.Name).ToList();
                model.FirstName = schoolboy.FirstName;
                model.LastName = schoolboy.LastName;
                model.SchoolboyId = schoolboy.Id;
                foreach (var group in groupedLessons)
                {
                    List<LessonItemViewModel> list = new List<LessonItemViewModel>();

                    foreach (var lesson in group)
                    {
                        LessonItemViewModel lessonViewModel = new LessonItemViewModel()
                        {
                            Name = lesson.Teaching.Name,
                            Id = lesson.Id,
                        };
                        list.Add(lessonViewModel);
                    }

                    model.Lessons.Add(group.Key, list);
                }

                var teachings = businessContext.TeachingManager.All();
                foreach (var teaching in teachings)
                {
                    var formattedLessons = new List<SmallLessonInfoViewModel>();
                    foreach (var lesson in teaching.Lessons)
                    {
                        formattedLessons.Add(new SmallLessonInfoViewModel()
                        {
                            FormattedTimeAndDay = string.Format("{0}, {1} ({2})", 
                                DateHelper.GetDayNameByNumber(lesson.DayNumber),
                                DateHelper.GetFormattedTimeByPeriodNumber(lesson.PeriodNumber),
                                lesson.Classroom.Name),
                            LessonId = lesson.Id,
                        });
                    }

                    model.Teachings.Add(new SelectListItem()
                    {
                        Text = teaching.Name,
                        Value = JsonConvert.SerializeObject(formattedLessons),
                    });
                }
                
            }

            return View(model);
        }
    }
}