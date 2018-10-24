using System.Collections.Generic;
using DoctorAppointment.Api.Validators.Interfaces;
using DoctorAppointment.Database.Models;

namespace DoctorAppointment.Api.Validators
{
    public class AppointmentTimeRangeValidator : IListValidator<AppointmentModel>
    {
        public List<ValidationError> Validate(AppointmentModel appointment)
        {
            var validationErrors = new List<ValidationError>();

            if (appointment.Duration <= 0)
            {
                validationErrors.Add(new ValidationError("Duration can't be less then 0"));
            }

            return validationErrors;
        }
    }
}
