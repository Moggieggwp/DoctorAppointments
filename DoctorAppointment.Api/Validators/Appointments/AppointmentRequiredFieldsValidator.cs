using System.Collections.Generic;
using DoctorAppointment.Api.Validators.Interfaces;
using DoctorAppointment.Database.Models;

namespace DoctorAppointment.Api.Validators
{
    public class AppointmentRequiredFieldsValidator : IListValidator<AppointmentModel>
    {
        public List<ValidationError> Validate(AppointmentModel appointment)
        {
            var validationErrors = new List<ValidationError>();

            if (appointment.Id == 0)
            {
                validationErrors.Add(new ValidationError("Appointment id can't be empty"));
            }

            if (appointment.DoctorId == 0)
            {
                validationErrors.Add(new ValidationError("Doctor can't be empty"));
            }

            if (appointment.RoomId == 0)
            {
                validationErrors.Add(new ValidationError("Room can't be empty"));
            }

            return validationErrors;
        }
    }
}
