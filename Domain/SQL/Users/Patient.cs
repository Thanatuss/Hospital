using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SQL.Users
{
    public class Patient : Domain.SQL.Base.Base
    {
        public string Fullname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }

        //        public ICollection<Appointment> Appointments { get; set; }

    }
}
