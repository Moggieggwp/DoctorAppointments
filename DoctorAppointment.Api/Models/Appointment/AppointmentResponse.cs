using System;
using DoctorAppointment.Api.Models.Room;

namespace DoctorAppointment.Api.Models
{
    /// <summary>
    /// represents a single appointment data retured by the api to client
    /// </summary>
    public class AppointmentResponse
    {
        public int Id { get; set; }
        public DoctorModel Doctor { get; set; }
        public DateTimeOffset Time { get; set; }
        public decimal Duration { get; set; }
        public RoomModel Room { get; set; }
    }
}
