using System;
using System.Collections.Generic;
using System.Linq;
using DoctorAppointment.Api.Services;
using DoctorAppointment.Api.Services.Interfaces;
using DoctorAppointment.Api.Validators.Interfaces;
using DoctorAppointment.Database.Models;
using DoctorAppointment.Database.Repositories.Appointment.Interfaces;

namespace DoctorAppointment.Api.Validators
{
    public class AppointmentCollisionValidator : IListValidator<AppointmentModel>
    {
        private readonly IAppointmentReadRepository appointmentReadRepository;
        private readonly IApplicationMappingService applicationMappingService;

        public AppointmentCollisionValidator(
            IAppointmentReadRepository appointmentReadRepository,
            IApplicationMappingService applicationMappingService)
        {
            this.appointmentReadRepository = appointmentReadRepository;
            this.applicationMappingService = applicationMappingService;
        }

        public List<ValidationError> Validate(AppointmentModel appointment)
        {
            var validationErrors = new List<ValidationError>();

            var appointments = this.appointmentReadRepository
                .GetAppointmentsByDoctorId(appointment.DoctorId).Select(this.applicationMappingService.MapToAppointmentModel).ToList();

            if (CheckIfDoctorHasAppointmentForCurrentTime(appointment, appointments))
            {
                validationErrors.Add(new ValidationError("Doctor has appointment for current time"));
            }

            return validationErrors;
        }

        private bool CheckIfDoctorHasAppointmentForCurrentTime(AppointmentModel appointment, List<AppointmentModel> appointments)
        {
            if (appointments.Any())
            {
                return true;
            }

            DateTimeOffset appointmentStart = appointment.Time;
            DateTimeOffset appointmentEnd = appointment.Time.AddMinutes((double)appointment.Duration);

            return appointments.Any(x => (x.Time > appointmentStart
                  && x.Time < appointmentEnd)
                 || (x.Time.AddMinutes((double)x.Duration) > appointmentStart
                     && x.Time.AddMinutes((double)x.Duration) < appointmentEnd));
        }
    }
}
