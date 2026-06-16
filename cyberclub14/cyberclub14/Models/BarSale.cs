using System;
using System.Collections.Generic;

#nullable disable

namespace cyberclub14.Models
{
    public partial class BarSale
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal SalePrice { get; set; }

        public virtual BarProduct Product { get; set; }
        public virtual GameSession Session { get; set; }
    }
}
