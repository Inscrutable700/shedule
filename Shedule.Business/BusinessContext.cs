using Shedule.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shedule.Business
{
    public class BusinessContext  : IDisposable
    {
        /// <summary>
        /// The data context.
        /// </summary>
        private DataContext dataContext;

        /// <summary>
        /// The lesson manager.
        /// </summary>
        private LessonManager lessonManager;

        /// <summary>
        /// The schoolboy manager.
        /// </summary>
        private SchoolboyManager schoolboyManager;

        /// <summary>
        /// The teaching manager.
        /// </summary>
        private TeachingManager teachingManager;

        /// <summary>
        /// The classroom manager.
        /// </summary>
        private ClassroomManager classroomManager;

        /// <summary>
        /// The teacher manager.
        /// </summary>
        private TeacherManager teacherManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessContext"/> class.
        /// </summary>
        public BusinessContext()
        {
            this.dataContext = new DataContext();
        }

        /// <summary>
        /// Gets the lesson manager.
        /// </summary>
        public LessonManager LessonManager
        {
            get
            {
                if (this.lessonManager == null)
                {
                    this.lessonManager = new LessonManager(this.dataContext);
                }

                return this.lessonManager;
            }
        }

        /// <summary>
        /// Gets the schoolboy manager.
        /// </summary>
        public SchoolboyManager SchoolboyManager
        {
            get
            {
                if (this.schoolboyManager == null)
                {
                    this.schoolboyManager = new SchoolboyManager(this.dataContext);
                }

                return this.schoolboyManager;
            }
        }

        /// <summary>
        /// Gets the teaching manager.
        /// </summary>
        public TeachingManager TeachingManager
        {
            get
            {
                if (this.teachingManager == null)
                {
                    this.teachingManager = new TeachingManager(this.dataContext);
                }

                return this.teachingManager;
            }
        }

        /// <summary>
        /// Gets the classroom manager.
        /// </summary>
        public ClassroomManager ClassroomManager
        {
            get
            {
                if (this.classroomManager == null)
                {
                    this.classroomManager = new ClassroomManager(this.dataContext);
                }

                return this.classroomManager;
            }
        }

        /// <summary>
        /// Gets the teacher manager.
        /// </summary>
        public TeacherManager TeacherManager
        {
            get
            {
                if (this.teacherManager == null)
                {
                    this.teacherManager = new TeacherManager(this.dataContext);
                }

                return this.teacherManager;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this.dataContext != null)
            {
                this.dataContext.Dispose();
            }
        }
    }
}
