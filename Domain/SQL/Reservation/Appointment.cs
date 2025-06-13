using Domain.SQL.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SQL.Reservation
{
    public class Appointment : Domain.SQL.Base.Base
    {
        public int DoctorId { get; set; }
        public Domain.SQL.Users.Docter Doctor { get; set; }
        public int PatientId { get; set; }
        public Domain.SQL.Users.Patient Patient { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public bool IsCanceled { get; set; } = false;
    }
}
