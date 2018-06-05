using System.Collections.Generic;
namespace DoctorAppointment.Database.Repositories.Appointment.Interfaces
{
    public interface IAppointmentReadRepository
    {
        List<Entities.Appointment> GetAppointmentsByDoctorName(string doctorName);
        List<Entities.Appointment> GetAppointments();
    }
}
