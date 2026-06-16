using System;
using System.Collections.Generic;

#nullable disable

namespace komunalka11.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int AccrualId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal AmountPaid { get; set; }

        public virtual Accrual Accrual { get; set; }
    }
}
