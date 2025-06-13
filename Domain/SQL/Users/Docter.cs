using Domain.SQL.Docter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SQL.Users
{
    public class Docter : Domain.SQL.Base.Base
    {
        public string Fullname { get; set; }
        public string PhoneNumber { get; set; }
        public string Image { get; set; }
        public Domain.SQL.Docter.Specialty Specialty { get; set; }
        //        public ICollection<TimeSlot> TimeSlots { get; set; }
        //        public ICollection<Appointment> Appointments { get; set; }


    }
}
