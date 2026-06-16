using System;
using System.Collections.Generic;

#nullable disable

namespace restoran9.Models
{
    public partial class Orderitem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int DishId { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtTime { get; set; }

        public virtual Dish Dish { get; set; }
        public virtual Order Order { get; set; }
    }
}
