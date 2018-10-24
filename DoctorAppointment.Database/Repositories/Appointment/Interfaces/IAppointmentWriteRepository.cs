namespace DoctorAppointment.Database.Repositories.Appointment.Interfaces
{
    public interface IAppointmentWriteRepository
    {
        Entities.Appointment AddAppointment(Entities.Appointment appointment);
        Entities.Appointment UpdateAppointment(Entities.Appointment appointment);
    }
}
