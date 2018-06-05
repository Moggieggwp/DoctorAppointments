using DoctorAppointment.Database.Entities;
using DoctorAppointment.Database.Models;

namespace DoctorAppointment.Api.Services
{
    public static class AppointmentMapper
    {
        public static AppointmentModel MapToModel(Appointment appointment)
        {
            return new AppointmentModel
            {
                Id = appointment.Id,
                Doctor = appointment.Doctor,
                Time = appointment.Time,
                Duration = appointment.Duration
            };
        }

        public static Appointment MapToEntity(AppointmentModel appointmentModel)
        {
            return new Appointment
            {
                Id = appointmentModel.Id,
                Doctor = appointmentModel.Doctor,
                Time = appointmentModel.Time,
                Duration = appointmentModel.Duration
            };
        }
    }
}
