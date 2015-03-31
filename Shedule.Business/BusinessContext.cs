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
        private DataContext dataContext;

        private LessonManager lessonManager;

        private SchoolboyManager schoolboyManager;

        private TeachingManager teachingManager;

        public BusinessContext()
        {
            this.dataContext = new DataContext();
        }

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

        public void Dispose()
        {
            if (this.dataContext != null)
            {
                this.dataContext.Dispose();
            }
        }
    }
}
