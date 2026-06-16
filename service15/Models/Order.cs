using System;
using System.Collections.Generic;

#nullable disable

namespace service15.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
        public int ServiceId { get; set; }
        public string ExecutionAddress { get; set; }
        public DateTime ExecutionDate { get; set; }
        public string OrderStatus { get; set; }

        public virtual Client Client { get; set; }
        public virtual Master Master { get; set; }
        public virtual Service Service { get; set; }
    }
}
