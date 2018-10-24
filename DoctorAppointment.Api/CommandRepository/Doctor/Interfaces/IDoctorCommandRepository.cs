using DoctorAppointment.Api.Models;
using DoctorAppointment.Api.Validators;

namespace DoctorAppointment.Api.CommandRepository.Doctor.Interfaces
{
    public interface IDoctorCommandRepository
    {
        OperationResult<DoctorModel> AddDoctor(DoctorRequest commandData);
        OperationResult<DoctorModel> UpdateDoctor(DoctorRequest commandData);
    }
}
