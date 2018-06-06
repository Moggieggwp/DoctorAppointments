using System.Collections.Generic;
using System.Linq;
using DoctorAppointment.Api.Services;
using DoctorAppointment.Api.Validators.Interfaces;
using DoctorAppointment.Database.Models;
using DoctorAppointment.Database.Repositories.Appointment.Interfaces;
using DoctorAppointment.Database.Repositories.Room.Interfaces;

namespace DoctorAppointment.Api.Validators
{
    class AppointmentRoomAvailableValidator : IAppointmentValidator<AppointmentModel>
    {
        private readonly IAppointmentReadRepository appointmentReadRepository;

        public AppointmentRoomAvailableValidator(IAppointmentReadRepository appointmentReadRepository)
        {
            this.appointmentReadRepository = appointmentReadRepository;
        }

        public List<ValidationError> Validate(AppointmentModel appointment)
        {
            var validationErrors = new List<ValidationError>();

            var appointments = this.appointmentReadRepository
               .GetAppointments().Select(AppointmentMapper.MapToModel).ToList();

            if (CheckIfRoomIsBusyForCurrentTime(appointment, appointments))
            {
                validationErrors.Add(new ValidationError("This room is not available for current time"));
            }

            return validationErrors;
        }

        private bool CheckIfRoomIsBusyForCurrentTime(AppointmentModel appointment, List<AppointmentModel> appointments)
        {
            if (appointments.Any())
            {
                return true;
            }

            var appointmentStart = appointment.Time;
            var appointmentEnd = appointment.Time.AddMinutes((double)appointment.Duration);

            return appointments.Any(x => (x.Time > appointmentStart
                  && x.Time < appointmentEnd)
                 || (x.Time.AddMinutes((double)x.Duration) > appointmentStart
                     && x.Time.AddMinutes((double)x.Duration) < appointmentEnd) && x.RoomNumber == appointment.RoomNumber);
        }
    }
}
