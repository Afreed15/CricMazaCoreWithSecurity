using System;
using System.Collections.Generic;

namespace WebApplication28.Models
{
    public partial class PointsTable
    {
        public int Ptid { get; set; }
        public int? Tid { get; set; }
        public int Played { get; set; }
        public double NetRate { get; set; }
        public int Win { get; set; }
        public int Loss { get; set; }
        public int Points { get; set; }

        public virtual Teams T { get; set; }
    }
}
