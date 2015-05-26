using Shedule.Business;
using Shedule.Data.Model;
using Shedule.Web.ViewModels;
using System.Web.Mvc;
using System.Net.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Host.SystemWeb;
using AutoMapper;
using System.Collections.Generic;

namespace Shedule.Web.Controllers
{
    /// <summary>
    /// The schoolboy controller.
    /// </summary>
    [Authorize]
    public class SchoolboyController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SchoolboyController"/> class.
        /// </summary>
        public SchoolboyController()
        {
            Mapper.CreateMap<Tariff, SchoolboyViewModel.TariffItemViewModel>()
                .ForMember(dest => dest.TeachingName, ost => ost.MapFrom(src => src.Teaching.Name));
        }

        /// <summary>
        /// Index page.
        /// </summary>
        /// <returns>The index page for schoolboys.</returns>
        [Authorize]
        public ActionResult Index()
        {
            using (BusinessContext businessContext = new BusinessContext())
            {
                var schoolBoys = businessContext.SchoolboyManager.AllSchoolboys();

                return View(schoolBoys);
            }
        }

        /// <summary>
        /// Schoolboys the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            SchoolboyViewModel model = null;

            using (BusinessContext businessContext = new BusinessContext())
            {
                Schoolboy schoolboy = businessContext.SchoolboyManager.Get(id);
                model = new SchoolboyViewModel()
                {
                    Id = schoolboy.Id,
                    Age = schoolboy.Age,
                    FirstName = schoolboy.FirstName,
                    LastName = schoolboy.LastName,
                    Adress = schoolboy.Adress,
                    Birthday = schoolboy.Birthday,
                    Email = schoolboy.Email,
                    PhoneNumber = schoolboy.PhoneNumber,
                };

                foreach (var schoolboyToTariff in schoolboy.SchoolboyToTariffs)
                {
                    model.Tariffs.Add(new SchoolboyViewModel.TariffItemViewModel()
                    {
                        Id = schoolboyToTariff.Tariff.Id,
                        CountOfPairs = schoolboyToTariff.Tariff.CountOfPairs,
                        Price = schoolboyToTariff.Tariff.Price,
                        TeachingName = schoolboyToTariff.Tariff.Teaching.Name,
                        Title = schoolboyToTariff.Tariff.Title,
                    });
                }
            }

            return View(model);
        }

        /// <summary>
        /// Adds this instance.
        /// </summary>
        /// <returns>The page for add new Schoolboy.</returns>
        public ActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>The Index page for schoolboys.</returns>
        [HttpPost]
        public ActionResult Add(SchoolboyViewModel model)
        {
            using (BusinessContext businessContext = new BusinessContext())
            {
                Schoolboy schoolboy = new Schoolboy()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age,
                    Email = model.Email,
                    Birthday = model.Birthday,
                    Adress = model.Adress,
                    PhoneNumber = model.PhoneNumber,
                };
                businessContext.SchoolboyManager.Add(schoolboy);
            }

            return RedirectToAction("Index", "Schoolboy");
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Index page for schoolboys.</returns>
        public ActionResult Delete(int id)
        {
            using (BusinessContext businessContext = new BusinessContext())
            {
                businessContext.SchoolboyManager.Delete(id);
            }
            return RedirectToAction("Index", "Schoolboy");
        }

        [HttpPost]
        public ActionResult AddLesson(int schoolboyId, int lessonId, int tariffId)
        {
            using (BusinessContext businessContext = new BusinessContext())
            {
                businessContext.SchoolboyManager.AddTariffForSchoolboy(schoolboyId, tariffId, lessonId);
            }

            return RedirectToAction("SheduleForSchoolboy", "Shedule", new { schoolboyId = schoolboyId});
        }

        public ActionResult DeleteTariff(int schoolboyId, int tariffId)
        {
            using (BusinessContext businessContext = new BusinessContext())
            {
                businessContext.SchoolboyManager.DeleteTariff(schoolboyId, tariffId);
            }

            return RedirectToAction("Details", new { id = schoolboyId});
        }
    }
}