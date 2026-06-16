using System;
using System.Collections.Generic;

#nullable disable

namespace trackingOfRequests12.Models
{
    public partial class RepairRequest
    {
        public RepairRequest()
        {
            RequestParts = new HashSet<RequestPart>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int DeviceId { get; set; }
        public int EmployeeId { get; set; }
        public string FaultDescription { get; set; }
        public string WorkList { get; set; }
        public decimal BaseWorkPrice { get; set; }
        public bool IsUrgent { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Client Client { get; set; }
        public virtual Device Device { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<RequestPart> RequestParts { get; set; }
    }
}
