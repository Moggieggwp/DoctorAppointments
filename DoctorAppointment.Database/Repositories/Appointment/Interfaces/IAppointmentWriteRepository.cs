using DoctorAppointment.Database.Models;

namespace DoctorAppointment.Database.Repositories.Appointment.Interfaces
{
    public interface IAppointmentWriteRepository
    {
        Entities.Appointment AddAndReturnAppointment(string doctorName, AppointmentRequest appRequest);

    }
}
