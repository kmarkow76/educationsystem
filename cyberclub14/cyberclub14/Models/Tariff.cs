using System;
using System.Collections.Generic;

#nullable disable

namespace cyberclub14.Models
{
    public partial class Tariff
    {
        public Tariff()
        {
            GameSessions = new HashSet<GameSession>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PricePerHour { get; set; }
        public bool? IsNightPackage { get; set; }

        public virtual ICollection<GameSession> GameSessions { get; set; }
    }
}
