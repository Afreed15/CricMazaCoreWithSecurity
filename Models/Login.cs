using System;
using System.Collections.Generic;

namespace WebApplication28.Models
{
    public partial class Login
    {
        public int Lid { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string Lrole { get; set; }
    }
}
