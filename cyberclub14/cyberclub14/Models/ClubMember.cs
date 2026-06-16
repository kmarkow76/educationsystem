using System;
using System.Collections.Generic;

#nullable disable

namespace cyberclub14.Models
{
    public partial class ClubMember
    {
        public ClubMember()
        {
            GameSessions = new HashSet<GameSession>();
        }

        public int Id { get; set; }
        public string Nickname { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public bool? HasClubCard { get; set; }

        public virtual ICollection<GameSession> GameSessions { get; set; }
    }
}
