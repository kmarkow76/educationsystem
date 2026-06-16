using System;
using System.Collections.Generic;

#nullable disable

namespace trackingOfRequests12.Models
{
    public partial class Client
    {
        public Client()
        {
            Devices = new HashSet<Device>();
            RepairRequests = new HashSet<RepairRequest>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public bool IsRegular { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
        public virtual ICollection<RepairRequest> RepairRequests { get; set; }
    }
}
