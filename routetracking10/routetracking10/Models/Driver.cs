using System;
using System.Collections.Generic;

#nullable disable

namespace routetracking10.Models
{
    public partial class Driver
    {
        public Driver()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string LicenseNumber { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
