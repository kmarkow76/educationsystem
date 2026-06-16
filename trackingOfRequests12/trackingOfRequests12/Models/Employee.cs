using System;
using System.Collections.Generic;

#nullable disable

namespace trackingOfRequests12.Models
{
    public partial class Employee
    {
        public Employee()
        {
            RepairRequests = new HashSet<RepairRequest>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }

        public virtual ICollection<RepairRequest> RepairRequests { get; set; }
    }
}
