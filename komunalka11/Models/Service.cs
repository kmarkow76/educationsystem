using System;
using System.Collections.Generic;

#nullable disable

namespace komunalka11.Models
{
    public partial class Service
    {
        public Service()
        {
            Accruals = new HashSet<Accrual>();
            MeterReadings = new HashSet<MeterReading>();
        }

        public int Id { get; set; }
        public string ServiceName { get; set; }
        public decimal Tariff { get; set; }

        public virtual ICollection<Accrual> Accruals { get; set; }
        public virtual ICollection<MeterReading> MeterReadings { get; set; }
    }
}
