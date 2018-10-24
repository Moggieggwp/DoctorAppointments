using DoctorAppointment.Api.Models;
using DoctorAppointment.Api.Validators.Interfaces;
using System.Collections.Generic;

namespace DoctorAppointment.Api.Validators.Doctor
{
    public class DoctorRequiredFieldsValidator : IListValidator<DoctorModel>
    {
        public List<ValidationError> Validate(DoctorModel doctor)
        {
            var validationErrors = new List<ValidationError>();

            if (doctor.Id == 0)
            {
                validationErrors.Add(new ValidationError("Doctor id can't be empty"));
            }

            if (string.IsNullOrEmpty(doctor.Name))
            {
                validationErrors.Add(new ValidationError("Doctor name can't be empty"));
            }

            if (string.IsNullOrEmpty(doctor.Specialization))
            {
                validationErrors.Add(new ValidationError("Doctor specialization can't be empty"));
            }

            return validationErrors;
        }
    }
}