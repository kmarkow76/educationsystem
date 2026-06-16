using System;
using System.Collections.Generic;

#nullable disable

namespace beauty5.Models
{
    public partial class Service
    {
        public Service()
        {
            AppointmentDetails = new HashSet<AppointmentDetail>();
        }

        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<AppointmentDetail> AppointmentDetails { get; set; }
    }
}
