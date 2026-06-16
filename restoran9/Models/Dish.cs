using System;
using System.Collections.Generic;

#nullable disable

namespace restoran9.Models
{
    public partial class Dish
    {
        public Dish()
        {
            Orderitems = new HashSet<Orderitem>();
        }

        public int DishId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public virtual ICollection<Orderitem> Orderitems { get; set; }
    }
}
