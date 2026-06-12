using System;
using System.Collections.Generic;

#nullable disable

namespace educsys.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Subject { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
