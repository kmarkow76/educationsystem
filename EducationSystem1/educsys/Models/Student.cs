using System;
using System.Collections.Generic;

#nullable disable

namespace educsys.Models
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string GroupName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
