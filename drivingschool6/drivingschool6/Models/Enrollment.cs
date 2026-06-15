using System;
using System.Collections.Generic;

#nullable disable

namespace drivingschool6.Models
{
    public partial class Enrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int InstructorId { get; set; }
        public int CarId { get; set; }
        public int CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public string PaymentType { get; set; }
        public string Status { get; set; }

        public virtual Vehicle Car { get; set; }
        public virtual Course Course { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual Student Student { get; set; }
    }
}
