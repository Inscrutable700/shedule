using Shedule.Data;
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
            Schoolboy schoolboy = this.dataContext.Schoolboys.Find(schoolboyID);

            return schoolboy;
        }

        /// <summary>
        /// Lists the specified lesson identifier.
        /// </summary>
        /// <param name="LessonID">The lesson identifier.</param>
        /// <returns>The list of scoolboys by Lesson.</returns>
        public Schoolboy[] List(int LessonID)
        {
            var lesson = this.dataContext.Lessons.Find(LessonID);
            return lesson.Schoolboys.ToArray();
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
            schoolboy.Lessons.AddRange(lessons);
            this.dataContext.SaveChanges();

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

        public void AddLessonForSchoolboy(int schoolboyId, int lessonId)
        {
            Schoolboy schoolboy = this.dataContext.Schoolboys.Include(s => s.Lessons)
                .Single(s => s.Id == schoolboyId);
            Lesson lesson = this.dataContext.Lessons.Find(lessonId);
            schoolboy.Lessons.Add(lesson);
            this.dataContext.SaveChanges();
        }
    }
}
