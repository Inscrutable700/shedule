using Shedule.Data.Model;
using System.Data.Entity;

namespace Shedule.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<Schoolboy> Schoolboys { get; set; }

        public DbSet<Classroom> Classrooms { get; set; }

        public DbSet<Teaching> Teachings { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Tariff> Tariffs { get; set; }

        public DbSet<SchoolboyToTariff> SchoolboyToTariffs { get; set; }
    }
}
