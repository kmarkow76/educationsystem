using System;
using System.Collections.Generic;

#nullable disable

namespace komunalka11.Models
{
    public partial class MeterReading
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int ServiceId { get; set; }
        public DateTime ReadingDate { get; set; }
        public decimal PreviousReading { get; set; }
        public decimal CurrentReading { get; set; }
        public decimal? Volume { get; set; }

        public virtual Account Account { get; set; }
        public virtual Service Service { get; set; }
    }
}
