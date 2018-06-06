using System;
using DoctorAppointment.Database.Commands;
using DoctorAppointment.Database.Entities;
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

        public Entities.Appointment AddAndReturnAppointment(Entities.Appointment appointment)
        {
            this.ExecuteCommand(new Command
            {
                Query = "insert into Appointments (Id, Doctor, Time, Duration, RoomNumber) values (@id, @doctor, @time, @duration, @roomNumber)",
                Parametrs = new { Id = appointment.Id, Doctor = appointment.Doctor, Time = appointment.Time, Duration = appointment.Duration, RoomNumber = appointment.RoomNumber },
                CommandType = CommandType.Insert
            });

            return this.GetById(appointment.Id, Tables.Appointments);
        }

        public Entities.Appointment UpdateAndReturnAppointment(Entities.Appointment appointment)
        {
            this.ExecuteCommand(new Command
            {
                Query = "update Appointments set Doctor = @doctor, Time = @time, Duration = @duration, RoomNumber = @romnumber where Id = @id)",
                Parametrs = new { Id = appointment.Id, Doctor = appointment.Doctor, Time = appointment.Time, Duration = appointment.Duration, RoomNumber = appointment.RoomNumber },
                CommandType = CommandType.Update
            });

            return this.GetById(appointment.Id, Tables.Appointments);
        }
    }
}
