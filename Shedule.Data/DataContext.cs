﻿using Shedule.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
