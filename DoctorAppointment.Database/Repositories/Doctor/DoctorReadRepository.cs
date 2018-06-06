using DoctorAppointment.Database.Repositories.Base;
using DoctorAppointment.Database.Repositories.Doctor.Interfaces;

namespace DoctorAppointment.Database.Repositories.Doctor
{
    public class DoctorReadRepository : BaseRepository<Entities.Doctor>, IDoctorReadRepository
    {
        private readonly string connectionString;

        public DoctorReadRepository(string connectionString) : base(connectionString)
        {
            this.connectionString = connectionString;
        }

        public Entities.Doctor GetDoctorById(int id)
        {
            return this.GetById(id, Tables.Doctors);
        }
    }
}
