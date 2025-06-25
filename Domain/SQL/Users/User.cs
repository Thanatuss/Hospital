using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.SQL.Base;
namespace Domain.SQL.Users
{
    public class User : Domain.SQL.Base.Base
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        //public Admin Admin { get; set; }
        //public UserRole Role { get; set; }
        //public UserRole Role { get; set; }

    }
    public enum UserRole{
        Admin ,
        Docter ,
        Patient
    }
}
