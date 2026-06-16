using System;
using System.Collections.Generic;

#nullable disable

namespace cyberclub14.Models
{
    public partial class GamingPlace
    {
        public GamingPlace()
        {
            GameSessions = new HashSet<GameSession>();
        }

        public int Id { get; set; }
        public int ZoneId { get; set; }
        public int PlaceNumber { get; set; }
        public string HardwareSpec { get; set; }
        public bool? IsOccupied { get; set; }

        public virtual GameZone Zone { get; set; }
        public virtual ICollection<GameSession> GameSessions { get; set; }
    }
}
