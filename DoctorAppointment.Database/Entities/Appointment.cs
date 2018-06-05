using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Database.Entities
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public string Doctor { get; set; }
        public DateTimeOffset Time { get; set; }
        public decimal Duration { get; set; }
    }
}
