using System;
using System.Collections.Generic;

#nullable disable

namespace agentstvo13.Models
{
    public partial class EventDetail
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int ContractorId { get; set; }

        public virtual Contractor Contractor { get; set; }
        public virtual Event Event { get; set; }
    }
}
