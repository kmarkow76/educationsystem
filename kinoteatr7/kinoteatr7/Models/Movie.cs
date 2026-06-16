using System;
using System.Collections.Generic;

#nullable disable

namespace kinoteatr7.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Sessions = new HashSet<Session>();
        }

        public int MovieId { get; set; }
        public string Title { get; set; }
        public int DurationMinutes { get; set; }
        public string Genre { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
