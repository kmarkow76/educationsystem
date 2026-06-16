using System;
using System.Collections.Generic;

#nullable disable

namespace pharmacy8.Models
{
    public partial class Receipt
    {
        public int Id { get; set; }
        public int DrugId { get; set; }
        public int SupplierId { get; set; }
        public int Quantity { get; set; }
        public decimal ReceiptPrice { get; set; }
        public DateTime ReceiptDate { get; set; }

        public virtual Drug Drug { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
