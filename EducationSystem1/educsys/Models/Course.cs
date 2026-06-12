using System;
using System.Collections.Generic;

#nullable disable

namespace educsys.Models
{
    public partial class Course
    {
        public Course()
        {
            Grades = new HashSet<Grade>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public int HoursCount { get; set; }
        public decimal PricePerHour { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
