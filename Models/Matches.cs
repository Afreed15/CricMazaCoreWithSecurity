using System;
using System.Collections.Generic;

namespace WebApplication28.Models
{
    public partial class Matches
    {
        public int Mid { get; set; }
        public int? Team1 { get; set; }
        public int? Team2 { get; set; }
        public string MatchList { get; set; }
        public DateTime Mdate { get; set; }
        public string Mtime { get; set; }
        public string Venue { get; set; }

        public virtual Teams Team1Navigation { get; set; }
        public virtual Teams Team2Navigation { get; set; }
    }
}
