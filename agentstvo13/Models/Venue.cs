using System;
using System.Collections.Generic;

#nullable disable

namespace agentstvo13.Models
{
    public partial class Venue
    {
        public Venue()
        {
            Events = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string VenueName { get; set; }
        public string Address { get; set; }
        public decimal RentalPrice { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
