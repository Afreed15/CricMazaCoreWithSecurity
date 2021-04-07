using System;
using System.Collections.Generic;

namespace WebApplication28.Models
{
    public partial class PlayerProfile
    {
        public int Profileid { get; set; }
        public string Country { get; set; }
        public int HighestScore { get; set; }
        public string Role { get; set; }
        public string BestBowling { get; set; }
        public int? Tid { get; set; }
        public int? Pid { get; set; }

        public virtual Players P { get; set; }
        public virtual Teams T { get; set; }
    }
}
