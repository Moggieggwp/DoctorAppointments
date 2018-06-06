using DoctorAppointment.Database.Models;

namespace DoctorAppointment.Database.Repositories.Appointment.Interfaces
{
    public interface IAppointmentWriteRepository
    {
        Entities.Appointment AddAndReturnAppointment(Entities.Appointment appointment);
        Entities.Appointment UpdateAndReturnAppointment(Entities.Appointment appointment);
    }
}
