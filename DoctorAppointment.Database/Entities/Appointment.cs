using System;

namespace DoctorAppointment.Database.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Doctor { get; set; }
        public DateTimeOffset Time { get; set; }
        public decimal Duration { get; set; }
        public int RoomNumber { get; set; }
    }
}
