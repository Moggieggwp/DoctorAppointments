using DoctorAppointment.Api.Models;
using DoctorAppointment.Api.Validators;

namespace DoctorAppointment.Api.Services.Interfaces
{
    public interface IDoctorService
    {
        DoctorModel GetDoctorById(int id);

        OperationResult<DoctorModel> AddDoctor(DoctorRequest appointmentRequest);

        OperationResult<DoctorModel> UpdateDoctor(DoctorRequest appointmentRequest);
    }
}
