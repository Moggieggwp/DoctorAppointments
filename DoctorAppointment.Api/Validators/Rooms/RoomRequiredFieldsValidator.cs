using DoctorAppointment.Api.Models.Room;
using DoctorAppointment.Api.Validators.Interfaces;
using System.Collections.Generic;

namespace DoctorAppointment.Api.Validators.Rooms
{
    public class RoomRequiredFieldsValidator : IListValidator<RoomModel>
    {
        public List<ValidationError> Validate(RoomModel room)
        {
            var validationErrors = new List<ValidationError>();

            if (room.Id == 0)
            {
                validationErrors.Add(new ValidationError("Room id can't be empty"));
            }

            if (string.IsNullOrEmpty(room.Name))
            {
                validationErrors.Add(new ValidationError("Room name can't be empty"));
            }

            if (room.Occupancy == 0)
            {
                validationErrors.Add(new ValidationError("Room name can't be empty"));
            }

            return validationErrors;
        }
    }
}