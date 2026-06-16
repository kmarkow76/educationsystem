using System;
using System.Collections.Generic;

#nullable disable

namespace trackingOfRequests12.Models
{
    public partial class Device
    {
        public Device()
        {
            RepairRequests = new HashSet<RepairRequest>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public string DeviceType { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<RepairRequest> RepairRequests { get; set; }
    }
}
