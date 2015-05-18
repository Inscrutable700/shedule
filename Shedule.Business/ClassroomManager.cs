using Shedule.Data;
using Shedule.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shedule.Business
{
    public class ClassroomManager : ManagerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassroomManager"/> class.
        /// </summary>
        /// <param name="dataContext">The data context.</param>
        public ClassroomManager(DataContext dataContext)
            : base(dataContext)
        {
        }

        /// <summary>
        /// Adds the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="capacity">The capacity.</param>
        /// <returns>The classroom object.</returns>
        public Classroom Add(string name, int capacity, string buildingName)
        {
            Classroom classroom = new Classroom()
            {
                Name = name,
                Capacity = capacity,
                BuildingName = buildingName,
            };

            this.dataContext.Entry(classroom).State = System.Data.Entity.EntityState.Added;
            this.dataContext.SaveChanges();

            return classroom;
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The classroom object.</returns>
        public Classroom Get(int id)
        {
            return this.dataContext.Classrooms.Find(id);
        }

        /// <summary>
        /// Lists the specified building name.
        /// </summary>
        /// <param name="buildingName">Name of the building.</param>
        /// <returns>The array of classrooms.</returns>
        public Classroom[] List(string buildingName)
        {
            return this.dataContext.Classrooms.Where(c => string.Equals(c.BuildingName, buildingName)).ToArray();
        }

        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns>The array of classrooms.</returns>
        public Classroom[] All()
        {
            return this.dataContext.Classrooms.ToArray();
        }
    }
}
