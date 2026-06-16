using System;
using System.Collections.Generic;

#nullable disable

namespace beauty5.Models
{
    public partial class AppointmentDetail
    {
        public int DetailId { get; set; }
        public int AppointmentId { get; set; }
        public int ServiceId { get; set; }
        public int Quantity { get; set; }

        public virtual Appointment Appointment { get; set; }
        public virtual Service Service { get; set; }
    }
}
