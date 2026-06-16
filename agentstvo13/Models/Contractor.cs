using System;
using System.Collections.Generic;

#nullable disable

namespace agentstvo13.Models
{
    public partial class Contractor
    {
        public Contractor()
        {
            EventDetails = new HashSet<EventDetail>();
        }

        public int Id { get; set; }
        public string ContractorName { get; set; }
        public string ServiceType { get; set; }
        public decimal ServiceCost { get; set; }

        public virtual ICollection<EventDetail> EventDetails { get; set; }
    }
}
