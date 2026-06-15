using System;
using System.Collections.Generic;

#nullable disable

namespace drivingschool6.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int Id { get; set; }
        public string Make { get; set; }
        public string LicensePlate { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
