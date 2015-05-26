using AutoMapper;
using Shedule.Business;
using Shedule.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shedule.Web.Controllers
{
    [Authorize]
    public class ClassroomController : Controller
    {
        public ClassroomController()
        {
            //Mapper.CreateMap<>();
        }

        // GET: Classroom
        public ActionResult Index()
        {
            using (BusinessContext businessContext = new BusinessContext())
            {
                Classroom[] classrooms = businessContext.ClassroomManager.All();

                return View(classrooms);
            }
        }

        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The page for details about Classroom.</returns>
        public ActionResult Details(int id)
        {
            using(BusinessContext businessContext = new BusinessContext())
            {
                var model = businessContext.ClassroomManager.Get(id);
                return View(model);
            };
        }

        /// <summary>
        /// Deletes the specified classroom identifier.
        /// </summary>
        /// <param name="classroomId">The classroom identifier.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int classroomId)
        {
            using (BusinessContext businessContext = new BusinessContext())
            {
                businessContext.ClassroomManager.Delete(classroomId);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string name, int capacity, string buildingName)
        {
            using (BusinessContext businessContext = new BusinessContext())
            {
                businessContext.ClassroomManager.Add(name, capacity, buildingName);
            }

            return RedirectToAction("Index", "Classroom");
        }
    }
}