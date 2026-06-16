using System;
using System.Collections.Generic;

#nullable disable

namespace routetracking10.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public int RouteId { get; set; }
        public int VehicleId { get; set; }
        public int DriverId { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public DateTime TripDate { get; set; }
        public string Status { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual Route Route { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
