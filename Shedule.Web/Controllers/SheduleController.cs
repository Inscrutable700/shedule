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
    [Authorize]
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
                        PeriodNumber = lesson.PeriodNumber,
                        ClassroomName = lesson.Classroom.Name,
                        TeacherName = string.Format("{0} {1}", lesson.Teacher.FirstName, lesson.Teacher.LasName)
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
                var lessons = schoolboy.SchoolboyToTariffs.Select(st => st.Lesson).ToList();
                model.FirstName = schoolboy.FirstName;
                model.LastName = schoolboy.LastName;
                model.SchoolboyId = schoolboy.Id;
                foreach (var lesson in lessons)
                {
                    model.Days[lesson.DayNumber].Lessons.Add(new SheduleDayViewModel.LessonViewModel()
                    {
                        Id = lesson.Id,
                        Name = lesson.Teaching.Name,
                        PeriodNumber = lesson.PeriodNumber,
                        ClassroomName = lesson.Classroom.Name,
                        TeacherName = string.Format("{0} {1}", lesson.Teacher.FirstName, lesson.Teacher.LasName),
                        TeachingId = lesson.Teacher.Id,
                    });
                }

                var teachings = businessContext.TeachingManager.All();
                foreach (var teaching in teachings)
                {
                    var modelForTeaching = new LessonsAndTarifsForTeachingViewModel();
                    foreach (var lesson in teaching.Lessons)
                    {
                        modelForTeaching.Lessons.Add(new LessonsAndTarifsForTeachingViewModel.LessonItemViewModel()
                        {
                            FormattedTimeAndDay = string.Format("{0}, {1} ({2})", 
                                DateHelper.GetDayNameByNumber(lesson.DayNumber),
                                DateHelper.GetFormattedTimeByPeriodNumber(lesson.PeriodNumber),
                                lesson.Classroom.Name),
                            LessonId = lesson.Id,
                        });
                    }

                    foreach (var tariff in teaching.Tariffs)
                    {
                        modelForTeaching.Tariffs.Add(new LessonsAndTarifsForTeachingViewModel.TariffItemViewModel()
                        {
                            TariffId = tariff.Id,
                            FormattedInfo = string.Format("{0}, {1} занятий/{2} грн", tariff.Title, tariff.CountOfPairs, tariff.Price),
                        });
                    }

                    model.Teachings.Add(new SelectListItem()
                    {
                        Text = teaching.Name,
                        Value = JsonConvert.SerializeObject(modelForTeaching),
                    });
                }
                
            }

            return View(model);
        }

        public ActionResult SheduleForTeacher(int teacherId)
        {
            var model = new SheduleForTeacher();
            using (BusinessContext businessContext = new BusinessContext())
            {
                var teacher = businessContext.TeacherManager.Get(teacherId);
                
                model.FirstName = teacher.FirstName;
                model.LastName = teacher.LasName;
                model.TeacherId = teacher.Id;
                foreach (var lesson in teacher.Lessons)
                {
                    model.Days[lesson.DayNumber].Lessons.Add(new SheduleDayViewModel.LessonViewModel()
                    {
                        Id = lesson.Id,
                        Name = lesson.Teaching.Name,
                        PeriodNumber = lesson.PeriodNumber,
                        ClassroomName = lesson.Classroom.Name,
                        TeacherName = string.Format("{0} {1}", lesson.Teacher.FirstName, lesson.Teacher.LasName),
                        TeachingId = lesson.Teacher.Id,
                    });
                }

                var teachings = businessContext.TeachingManager.All();
                foreach (var teaching in teachings)
                {
                    var modelForTeaching = new LessonsAndTarifsForTeachingViewModel();
                    foreach (var lesson in teaching.Lessons)
                    {
                        modelForTeaching.Lessons.Add(new LessonsAndTarifsForTeachingViewModel.LessonItemViewModel()
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
                        Value = JsonConvert.SerializeObject(modelForTeaching),
                    });
                }

            }

            return View(model);
        }
    }
}