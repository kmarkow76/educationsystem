using System;
using System.Collections.Generic;

#nullable disable

namespace routetracking10.Models
{
    public partial class Route
    {
        public Route()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public string RouteNumber { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public decimal BasePrice { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
