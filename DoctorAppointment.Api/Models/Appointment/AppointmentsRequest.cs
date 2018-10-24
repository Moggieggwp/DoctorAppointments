using System;

namespace DoctorAppointment.Database.Models
{
    /// <summary>
    /// represents a "data on the wire", i.e. content of the request used to create an Appointment
    /// </summary>
    public class AppointmentRequest
    {
        public DateTimeOffset Time { get; set; }
        public decimal Duration { get; set; }
        public int DoctorId { get; set; }
        public int RoomId { get; set; }
    }
}
