using System;
using System.Collections.Generic;

#nullable disable

namespace komunalka11.Models
{
    public partial class Account
    {
        public Account()
        {
            Accruals = new HashSet<Accrual>();
            MeterReadings = new HashSet<MeterReading>();
        }

        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string Address { get; set; }
        public int CitizenId { get; set; }

        public virtual Citizen Citizen { get; set; }
        public virtual ICollection<Accrual> Accruals { get; set; }
        public virtual ICollection<MeterReading> MeterReadings { get; set; }
    }
}
