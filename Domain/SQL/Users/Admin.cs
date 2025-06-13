using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SQL.Users
{
    public class Admin : Domain.SQL.Base.Base
    {
        public string Fullname { get; set; }
        public string PhoneNumber { get; set; }
        public User User { get; set; }
        public string? Department { get; set; }
        public string Image { get; set; }



    }
}
