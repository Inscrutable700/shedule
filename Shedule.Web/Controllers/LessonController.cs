using AutoMapper;
using Shedule.Business;
using Shedule.Data.Model;
using Shedule.Web.ViewModels;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Shedule.Web.Controllers
{
    public class LessonController : Controller
    {
        public LessonController()
        {
            Mapper.CreateMap<Teacher, SelectListItem>()
                .ForMember(dist => dist.Text, ost => ost.MapFrom(src => string.Format("{0} {1}", src.FirstName, src.LasName)))
                .ForMember(dist => dist.Value, ost => ost.MapFrom(src => src.Id));

            Mapper.CreateMap<Teaching, SelectListItem>()
                .ForMember(dist => dist.Text, ost => ost.MapFrom(src => src.Name))
                .ForMember(dist => dist.Value, ost => ost.MapFrom(src => src.Id));

            Mapper.CreateMap<Classroom, SelectListItem>()
                .ForMember(dist => dist.Text, ost => ost.MapFrom(src => src.Name))
                .ForMember(dist => dist.Value, ost => ost.MapFrom(src => src.Id));
        }

        public ActionResult Add()
        {
            AddLessonViewModel model = new AddLessonViewModel();
            using (BusinessContext businessContext = new BusinessContext())
            {
                var teachers = businessContext.TeacherManager.All();
                model.Teachers = Mapper.Map<Teacher[], List<SelectListItem>>(teachers);
                var teachings = businessContext.TeachingManager.All();
                model.Teachings = Mapper.Map<List<Teaching>, List<SelectListItem>>(teachings);
                var classrooms = businessContext.ClassroomManager.All();
                model.Classrooms = Mapper.Map<Classroom[], List<SelectListItem>>(classrooms);
            }

            return View(model);
        }

        [HttpPost]
        //[Authorize(Roles="admin")]
        public ActionResult Add(LessonViewModel model)
        
        {
            Lesson lesson = null;
            using (BusinessContext businessContext = new BusinessContext())
            {
                lesson = businessContext.LessonManager.Add(
                    model.TeachingId,
                    model.PeriodNumber,
                    model.TeacherId,
                    model.DayOfWeekNumber,
                    model.ClassroomId);
            }

            return RedirectToAction("Add", "Lesson");
        }

        public ActionResult Details(int lessonId)
        {
            return View();
        }
    }
}