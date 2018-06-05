using System;
using DoctorAppointment.Database.Commands;
using DoctorAppointment.Database.Models;
using DoctorAppointment.Database.Repositories.Appointment.Interfaces;
using DoctorAppointment.Database.Repositories.Base;

namespace DoctorAppointment.Database.Repositories
{
    public class AppointmentWriteRepository : BaseRepository<Entities.Appointment>, IAppointmentWriteRepository
    {
        private readonly string connectionString;

        public AppointmentWriteRepository(string connectionString) : base(connectionString)
        {
            this.connectionString = connectionString;
        }

        public Entities.Appointment AddAndReturnAppointment(string doctorName, AppointmentRequest appointmentRequest)
        {
            var id = Guid.NewGuid();

            this.ExecuteCommand(new Command
            {
                Query = "insert into Appointments (Id, Doctor, Time, Duration) values (@id, @doctor, @time, @duration)",
                Parametrs = new { Id = id, Doctor = doctorName, Time = appointmentRequest.Time, Duration = appointmentRequest.Duration },
                CommandType = CommandType.Insert
            });

            return this.GetById(id, Tables.Appointments);
        }
    }
}
