using DoctorAppointment.Database.Commands;
using DoctorAppointment.Database.Repositories.Base;
using DoctorAppointment.Database.Repositories.Doctor.Interfaces;

namespace DoctorAppointment.Database.Repositories.Doctor
{
    public class DoctorWriteRepository : BaseRepository<Entities.Doctor>, IDoctorWriteRepository
    {
        private readonly string connectionString;

        public DoctorWriteRepository(string connectionString) : base(connectionString)
        {
            this.connectionString = connectionString;
        }

        public Entities.Doctor AddDoctor(Entities.Doctor doctor)
        {
            this.ExecuteCommand(new Command
            {
                Query = "insert into Doctors (Id, Name, Specialization, WorkExperience) values (@id, @name, @specialization, @workExperience)",
                Parametrs = new { doctor.Id, doctor.Name, doctor.Specialization, doctor.WorkExperience },
                CommandType = CommandType.Insert
            });

            return this.GetById(doctor.Id, Tables.Doctors);
        }

        public Entities.Doctor UpdateDoctor(Entities.Doctor doctor)
        {
            this.ExecuteCommand(new Command
            {
                Query = "update Doctors set Name = @name, Specialization = @Specialization, WorkExperience = @workExperience where Id = @id",
                Parametrs = new { doctor.Id, doctor.Name, doctor.Specialization, doctor.WorkExperience },
                CommandType = CommandType.Update
            });

            return this.GetById(doctor.Id, Tables.Doctors);
        }
    }
}
