using System;
using System.Collections.Generic;

#nullable disable

namespace cyberclub14.Models
{
    public partial class GameZone
    {
        public GameZone()
        {
            GamingPlaces = new HashSet<GamingPlace>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<GamingPlace> GamingPlaces { get; set; }
    }
}
