using DoctorAppointment.Api.Validators;
using DoctorAppointment.Database.Models;

namespace DoctorAppointment.Api.CommandRepository.Interfaces
{
    public interface IAppointmentCommandRepository
    {
        OperationResult<AppointmentModel> AddApointment(AppointmentRequest commandData);
        OperationResult<AppointmentModel> UpdateApointment(AppointmentRequest commandData);
    }
}
