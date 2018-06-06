namespace DoctorAppointment.Database.Repositories.Doctor.Interfaces
{
    public interface IDoctorReadRepository
    {
        Entities.Doctor GetDoctorById(int id);
    }
}
