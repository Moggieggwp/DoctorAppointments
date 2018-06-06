using System;
using System.Collections.Generic;
using DoctorAppointment.Api.Validators;
using DoctorAppointment.Database.Models;

namespace DoctorAppointment.Api.Services.Interfaces
{
    public interface IAppointmentService
    {
        List<AppointmentModel> GetAppointmentsByDoctorName(string doctorName);
        AppointmentModel GetAppointmentById(int id);

        OperationResult<AppointmentModel> AddAndReturnAppointment(AppointmentRequest appointmentRequest);
        OperationResult<AppointmentModel> UpdateAndReturnAppointment(AppointmentRequest appointmentRequest);
    }
}
