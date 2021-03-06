﻿using Shedule.Data;
using Shedule.Data.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Shedule.Business
{
    /// <summary>
    /// The Schoolboy manager.
    /// </summary>
    public class SchoolboyManager : ManagerBase 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SchoolboyManager"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public SchoolboyManager(DataContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Gets the specified schoolboy identifier.
        /// </summary>
        /// <param name="schoolboyID">The schoolboy identifier.</param>
        /// <returns>The schoolboy.</returns>
        public Schoolboy Get(int schoolboyID)
        {
            Schoolboy schoolboy = this.dataContext.Schoolboys
                .Include(s => s.SchoolboyToTariffs.Select(t => t.Lesson.Teaching))
                .Include(s => s.SchoolboyToTariffs.Select(st => st.Tariff))
                .Single(s => s.Id == schoolboyID);

            return schoolboy;
        }

        /// <summary>
        /// Lists the specified lesson identifier.
        /// </summary>
        /// <param name="LessonID">The lesson identifier.</param>
        /// <returns>The list of scoolboys by Lesson.</returns>
        public Schoolboy[] List(int lessonID)
        {
            return this.dataContext.SchoolboyToTariffs
                .Where(st => st.LessonId == lessonID)
                .Select(st => st.Schoolboy)
                .ToArray();
        }

        /// <summary>
        /// Alls the schoolboys.
        /// </summary>
        /// <returns>The array of all schoolboys.</returns>
        public Schoolboy[] AllSchoolboys()
        {
            return this.dataContext.Schoolboys.ToArray();
        }

        /// <summary>
        /// Adds the specified schoolboy.
        /// </summary>
        /// <param name="schoolboy">The schoolboy.</param>
        /// <returns>The schoolboy.</returns>
        public Schoolboy Add(Schoolboy schoolboy)
        {
            var newSchoolboy = this.dataContext.Schoolboys.Add(schoolboy);
            this.dataContext.SaveChanges();
            return newSchoolboy;
        }

        /// <summary>
        /// Adds the specified schoolboy.
        /// </summary>
        /// <param name="schoolboy">The schoolboy.</param>
        /// <param name="lessons">The lessons.</param>
        /// <returns>The schoolboy.</returns>
        public Schoolboy Add(Schoolboy schoolboy, List<Lesson> lessons)
        {
            schoolboy = this.dataContext.Schoolboys.Add(schoolboy);
            /*schoolboy.Lessons.AddRange(lessons);
            this.dataContext.SaveChanges();*/

            return schoolboy;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The school boy identifier.</param>
        public void Delete(int id)
        {
            var entity = this.dataContext.Schoolboys.SingleOrDefault(t => t.Id == id);
            this.dataContext.Entry(entity).State = EntityState.Deleted;
            this.dataContext.SaveChanges();
        }

        //public void AddLessonForSchoolboy(int schoolboyId, int lessonId)
        //{
        //    Schoolboy schoolboy = this.dataContext.Schoolboys.Include(s => s.Lessons)
        //        .Single(s => s.Id == schoolboyId);
        //    Lesson lesson = this.dataContext.Lessons.Find(lessonId);
        //    schoolboy.Lessons.Add(lesson);
        //    this.dataContext.SaveChanges();
        //}

        public void AddTariffForSchoolboy(int schoolboyId, int tariffId, int lessonId)
        {
            var allTariffs = this.dataContext.SchoolboyToTariffs.Where(st => st.SchoolboyId == schoolboyId);

            Lesson lesson = this.dataContext.Lessons.Find(lessonId);

            bool result = allTariffs.Any(t => t.Lesson.DayNumber == lesson.DayNumber && t.Lesson.PeriodNumber == lesson.PeriodNumber);

            if (!result)
            {
                this.dataContext.SchoolboyToTariffs.Add(new SchoolboyToTariff()
                {
                    LessonId = lessonId,
                    SchoolboyId = schoolboyId,
                    TariffId = tariffId,
                });
                this.dataContext.SaveChanges();
            }
        }

        public void DeleteTariff(int schoolboyId, int tariffId)
        {
            SchoolboyToTariff schoolboyToTariff = this.dataContext.SchoolboyToTariffs
                .Single(st => st.SchoolboyId == schoolboyId && st.TariffId == tariffId);

            this.dataContext.SchoolboyToTariffs.Remove(schoolboyToTariff);
            this.dataContext.SaveChanges();
        }
    }
}
