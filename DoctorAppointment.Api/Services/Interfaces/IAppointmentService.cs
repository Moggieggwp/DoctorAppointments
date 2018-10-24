using System;
using System.Collections.Generic;
using DoctorAppointment.Api.Models;
using DoctorAppointment.Api.Validators;
using DoctorAppointment.Database.Models;

namespace DoctorAppointment.Api.Services.Interfaces
{
    public interface IAppointmentService
    {
        List<AppointmentResponse> GetAppointmentsByDoctorId(int doctorId);
        AppointmentResponse GetAppointmentById(int id);

        OperationResult<AppointmentModel> AddAppointment(AppointmentRequest appointmentRequest);
        OperationResult<AppointmentModel> UpdateAppointment(AppointmentRequest appointmentRequest);
    }
}
