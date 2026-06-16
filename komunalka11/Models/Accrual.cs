using System;
using System.Collections.Generic;

#nullable disable

namespace komunalka11.Models
{
    public partial class Accrual
    {
        public Accrual()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public int ServiceId { get; set; }
        public DateTime AccrualDate { get; set; }
        public decimal BaseAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal PenaltyAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public bool IsPaid { get; set; }

        public virtual Account Account { get; set; }
        public virtual Service Service { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
