using System.Collections.Generic;
using DoctorAppointment.Api.Validators;
using DoctorAppointment.Database.Models;

namespace DoctorAppointment.Api.Services.Interfaces
{
    public interface IAppointmentService
    {
        List<AppointmentModel> GetAppointmentsByDoctorName(string doctorName);
        OperationResult<AppointmentModel> AddAndReturnAppointment(string doctorName, AppointmentRequest appointmentRequest);
    }
}
