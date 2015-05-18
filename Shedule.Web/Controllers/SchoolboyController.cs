using Shedule.Business;
using Shedule.Data.Model;
using Shedule.Web.ViewModels;
using System.Web.Mvc;

namespace Shedule.Web.Controllers
{
    /// <summary>
    /// The schoolboy controller.
    /// </summary>
    public class SchoolboyController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SchoolboyController"/> class.
        /// </summary>
        public SchoolboyController()
        {
        }

        /// <summary>
        /// Index page.
        /// </summary>
        /// <returns>The index page for schoolboys.</returns>
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
            SchoolboyViewModel model = new SchoolboyViewModel();

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
                    Age = model.Age
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

        public ActionResult AddLesson(int SchoolboyId, int lessonId)
        {
            return RedirectToAction("Index", "");
        }
    }
}