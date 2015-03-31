﻿using AutoMapper;
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
    public class TeachingController : Controller
    {
        // GET: Teaching
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            List<Teaching> list = new List<Teaching>();
            using (BusinessContext businessContext = new BusinessContext())
            {
                list = businessContext.TeachingManager.All();
            }

            List<TeachingViewModel> model = Mapper.Map<List<Teaching>, List<TeachingViewModel>>(list);
            return View(model);
        }

        /// <summary>
        /// Gets the specified teaching identifier.
        /// </summary>
        /// <param name="teachingId">The teaching identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get(int teachingId)
        {

            using (BusinessContext businessContext = new BusinessContext())
            {
                var teaching = businessContext.TeachingManager.Get(teachingId);

                TeachingViewModel model = Mapper.Map<Teaching, TeachingViewModel>(teaching);

                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TeachingViewModel model)
        {
            using (BusinessContext businessContext = new BusinessContext())
            {
                Teaching teaching = Mapper.Map<TeachingViewModel, Teaching>(model);
                businessContext.TeachingManager.Create(teaching);
            }

            return RedirectToAction("Index", "Teaching");
        }

        public ActionResult Delete(int teachingId)
        {
            using (BusinessContext businessContext = new BusinessContext())
            {
                businessContext.TeachingManager.Delete(teachingId);
            }

            return RedirectToAction("Index", "Teaching");
        }
    }
}