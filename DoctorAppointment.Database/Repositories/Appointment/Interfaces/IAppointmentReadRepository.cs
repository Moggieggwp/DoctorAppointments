using System;
using System.Collections.Generic;
namespace DoctorAppointment.Database.Repositories.Appointment.Interfaces
{
    public interface IAppointmentReadRepository
    {
        List<Entities.Appointment> GetAppointmentsByDoctorId(int doctorId);
        List<Entities.Appointment> GetAppointments();
        Entities.Appointment GetAppointmentById(int id);
    }
}
