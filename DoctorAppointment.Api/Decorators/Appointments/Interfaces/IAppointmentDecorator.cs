using DoctorAppointment.Api.Validators;
using DoctorAppointment.Database.Models;

namespace DoctorAppointment.Api.Decorators.Interfaces
{
    public interface IAppointmentDecorator : IBaseDecorator
    {
        OperationResult<AppointmentModel> AddAppointment(AppointmentRequest commandData);
        OperationResult<AppointmentModel> UpdateAppointment(AppointmentRequest commandData);
    }
}
