using System;
using System.Collections.Generic;

#nullable disable

namespace cyberclub14.Models
{
    public partial class GameSession
    {
        public GameSession()
        {
            BarSales = new HashSet<BarSale>();
        }

        public int Id { get; set; }
        public int MemberId { get; set; }
        public int PlaceId { get; set; }
        public int TariffId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal BasePrice { get; set; }
        public int DiscountPercent { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }

        public virtual ClubMember Member { get; set; }
        public virtual GamingPlace Place { get; set; }
        public virtual Tariff Tariff { get; set; }
        public virtual ICollection<BarSale> BarSales { get; set; }
    }
}
