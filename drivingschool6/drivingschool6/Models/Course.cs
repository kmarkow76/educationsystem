using System;
using System.Collections.Generic;

#nullable disable

namespace drivingschool6.Models
{
    public partial class Course
    {
        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int Id { get; set; }
        public string Category { get; set; }
        public int NumberOfLessons { get; set; }
        public decimal BasePrice { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
