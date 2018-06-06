using System;
using System.Collections.Generic;
using System.Linq;
using DoctorAppointment.Database.Commands;
using DoctorAppointment.Database.Models;
using DoctorAppointment.Database.Repositories.Appointment.Interfaces;
using DoctorAppointment.Database.Repositories.Base;

namespace DoctorAppointment.Database.Repositories
{
    public class AppointmentReadRepository : BaseRepository<Entities.Appointment>, IAppointmentReadRepository
    {
        private readonly string connectionString;

        public AppointmentReadRepository(string connectionString) : base(connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Entities.Appointment> GetAppointmentsByDoctorName(string doctorName)
        {
            CommandResult<Entities.Appointment> result = this.ExecuteCommand(new Command
            {
                Query = "select * from Appointments where Doctor = @doctor",
                Parametrs = new { Doctor = doctorName },
                CommandType = CommandType.Select
            });

            return result.Data.ToList();
        }

        public List<Entities.Appointment> GetAppointments()
        {
            CommandResult<Entities.Appointment> result = this.ExecuteCommand(new Command
            {
                Query = "select * from Appointments",
                Parametrs = new { },
                CommandType = CommandType.Select
            });

            return result.Data.ToList();
        }

        public Entities.Appointment GetAppointmentById(int id)
        {
            return this.GetById(id, Tables.Appointments);
        }
    }
}
