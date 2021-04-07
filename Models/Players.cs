using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication28.Models
{
    public partial class Players
    {
        public Players()
        {
            PlayerProfile = new HashSet<PlayerProfile>();
        }

        public int Pid { get; set; }
        public string Tplayer { get; set; }
        public string Img { get; set; }
        public int? Tid { get; set; }
        [NotMapped]
        [DisplayName("Upload Profile Pic")]
        public IFormFile PPicFile { get; set; }
        public virtual Teams T { get; set; }

        public virtual ICollection<PlayerProfile> PlayerProfile { get; set; }
    }
}
