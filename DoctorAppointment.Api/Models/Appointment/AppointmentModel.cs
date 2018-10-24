using System;

namespace DoctorAppointment.Database.Models
{
    /// <summary>
    /// represents a single appointment data retured by the api to client
    /// </summary>
    public class AppointmentModel
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DateTimeOffset Time { get; set; }
        public decimal Duration { get; set; }
        public int RoomId { get; set; }
    }
}
