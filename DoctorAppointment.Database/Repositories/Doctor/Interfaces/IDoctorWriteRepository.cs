namespace DoctorAppointment.Database.Repositories.Doctor.Interfaces
{
    public interface IDoctorWriteRepository
    {
        Entities.Doctor AddDoctor(Entities.Doctor appointment);
        Entities.Doctor UpdateDoctor(Entities.Doctor appointment);
    }
}
