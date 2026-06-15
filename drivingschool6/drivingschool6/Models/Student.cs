using System;
using System.Collections.Generic;

#nullable disable

namespace drivingschool6.Models
{
    public partial class Student
    {
        public Student()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public bool? IsStudent { get; set; }
        public string FamilyCode { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
