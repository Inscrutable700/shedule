﻿using System;
using System.Collections.Generic;

namespace Shedule.Data.Model
{
    public class Teacher
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LasName { get; set; }

        public string MiddleName { get; set; }

        public string Description { get; set; }

        public string Degree { get; set; }

        public DateTime Birthday { get; set; }

        public List<Lesson> Lessons { get; set; }
    }
}
