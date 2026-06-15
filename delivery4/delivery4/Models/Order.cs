using System;
using System.Collections.Generic;

#nullable disable

namespace delivery4.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int CourierId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }

        public virtual Client Client { get; set; }
        public virtual Courier Courier { get; set; }
    }
}
