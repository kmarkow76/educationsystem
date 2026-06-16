using System;
using System.Collections.Generic;

#nullable disable

namespace trackingOfRequests12.Models
{
    public partial class RequestPart
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int PartId { get; set; }
        public int Quantity { get; set; }

        public virtual SparePart Part { get; set; }
        public virtual RepairRequest Request { get; set; }
    }
}
