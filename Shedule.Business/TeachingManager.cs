using Shedule.Data;
using Shedule.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shedule.Business
{
    public class TeachingManager : ManagerBase
    {
        public TeachingManager(DataContext dataContext)
            : base(dataContext)
        {
        }

        public Teaching Get(int teachingId)
        {
            return this.dataContext.Teachings
                .Include(t => t.Lessons.Select(l => l.Classroom))
                .Include(t => t.Tariffs)
                .SingleOrDefault(t => t.Id == teachingId);
        }

        public List<Teaching> All()
        {
            return this.dataContext.Teachings
                .Include(t => t.Lessons)
                .Include(t => t.Lessons.Select(l => l.Classroom))
                .ToList();
        }

        public Teaching Create(Teaching newTeaching)
        {
            this.dataContext.Entry(newTeaching).State = EntityState.Added;
            this.dataContext.SaveChanges();

            return newTeaching;
        }

        public void Delete(int id)
        {
            var entity = this.dataContext.Teachings.SingleOrDefault(t => t.Id == id);
            this.dataContext.Entry(entity).State = EntityState.Deleted;
            this.dataContext.SaveChanges();
        }

        public void AddTariff(int teachingId, string title, int countOfPairs, int price)
        {
            this.dataContext.Tariffs.Add(new Tariff()
            {
                TeachingId = teachingId,
                Title = title,
                CountOfPairs = countOfPairs,
                Price = price,
            });

            this.dataContext.SaveChanges();
        }

        public void DeleteTariff(int tariffId)
        {
            Tariff tariff = this.dataContext.Tariffs.Find(tariffId);
            this.dataContext.Entry(tariff).State = EntityState.Deleted;
            this.dataContext.SaveChanges();
        }
    }
}
