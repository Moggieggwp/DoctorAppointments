using System;
using System.Collections.Generic;
using System.Linq;
using DoctorAppointment.Api.Services;
using DoctorAppointment.Api.Validators.Interfaces;
using DoctorAppointment.Database.Models;
using DoctorAppointment.Database.Repositories.Appointment.Interfaces;

namespace DoctorAppointment.Api.Validators
{
    public class AppointmentCollisionValidator : IAppointmentValidator<AppointmentModel>
    {
        private readonly IAppointmentReadRepository appointmentReadRepository;

        public AppointmentCollisionValidator(IAppointmentReadRepository appointmentReadRepository)
        {
            this.appointmentReadRepository = appointmentReadRepository;
        }

        public List<ValidationError> Validate(AppointmentModel appointment)
        {
            var validationErrors = new List<ValidationError>();

            var appointments = this.appointmentReadRepository
                .GetAppointmentsByDoctorName(appointment.Doctor).Select(AppointmentMapper.MapToModel).ToList();

            if (CheckIfDoctorHasAppointmentForCurrentTime(appointment, appointments))
            {
                validationErrors.Add(new ValidationError("Collision"));
            }

            return validationErrors;
        }

        private bool CheckIfDoctorHasAppointmentForCurrentTime(AppointmentModel appointment, List<AppointmentModel> appointments)
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
                     && x.Time.AddMinutes((double)x.Duration) < appointmentEnd));
        }
    }
}
