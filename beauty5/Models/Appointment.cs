using System;
using System.Collections.Generic;

#nullable disable

namespace beauty5.Models
{
    public partial class Appointment
    {
        public Appointment()
        {
            AppointmentDetails = new HashSet<AppointmentDetail>();
        }

        public int AppointmentId { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }

        public virtual Client Client { get; set; }
        public virtual Master Master { get; set; }
        public virtual ICollection<AppointmentDetail> AppointmentDetails { get; set; }
    }
}
