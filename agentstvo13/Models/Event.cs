using System;
using System.Collections.Generic;

#nullable disable

namespace agentstvo13.Models
{
    public partial class Event
    {
        public Event()
        {
            EventDetails = new HashSet<EventDetail>();
        }

        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime ContractDate { get; set; }
        public DateTime EventDate { get; set; }
        public string PaymentStatus { get; set; }
        public int ClientId { get; set; }
        public int VenueId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Venue Venue { get; set; }
        public virtual ICollection<EventDetail> EventDetails { get; set; }
    }
}
