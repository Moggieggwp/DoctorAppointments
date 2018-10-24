using DoctorAppointment.Api.Models;
using DoctorAppointment.Api.Validators;

namespace DoctorAppointment.Api.Decorators.Doctors.Interfaces
{
    public interface IDoctorDecorator
    {
        OperationResult<DoctorModel> AddDoctor(DoctorRequest commandData);
        OperationResult<DoctorModel> UpdateDoctor(DoctorRequest commandData);
    }
}
