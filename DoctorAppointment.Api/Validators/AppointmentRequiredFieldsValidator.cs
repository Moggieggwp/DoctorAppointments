using System.Collections.Generic;
using DoctorAppointment.Api.Validators.Interfaces;
using DoctorAppointment.Database.Models;

namespace DoctorAppointment.Api.Validators
{
    public class AppointmentRequiredFieldsValidator : IAppointmentValidator<AppointmentModel>
    {
        public List<ValidationError> Validate(AppointmentModel appointment)
        {
            var validationErrors = new List<ValidationError>();

            if (string.IsNullOrEmpty(appointment.Doctor))
            {
                validationErrors.Add(new ValidationError("Doctor's name can't be empty"));
            }

            return validationErrors;
        }
    }

}
