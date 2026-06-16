using System;
using System.Collections.Generic;

#nullable disable

namespace routetracking10.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
