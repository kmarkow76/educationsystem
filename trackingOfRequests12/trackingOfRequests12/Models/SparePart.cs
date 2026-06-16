using System;
using System.Collections.Generic;

#nullable disable

namespace trackingOfRequests12.Models
{
    public partial class SparePart
    {
        public SparePart()
        {
            RequestParts = new HashSet<RequestPart>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }

        public virtual ICollection<RequestPart> RequestParts { get; set; }
    }
}
