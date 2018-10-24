using DoctorAppointment.Api.CommandRepository.Interfaces;
using DoctorAppointment.Api.Commands.Interfaces;
using DoctorAppointment.Api.Models;
using DoctorAppointment.Api.Validators;
using DoctorAppointment.Database.Models;

namespace DoctorAppointment.Api.CommandRepository
{
    public class AppointmentCommandRepository : IAppointmentCommandRepository
    {
        private readonly ICommand<AppointmentRequest, AppointmentModel> addAppointmentCommand;
        private readonly ICommand<AppointmentRequest, AppointmentModel> updateAppointmentCommand;

        public AppointmentCommandRepository(
            ICommand<AppointmentRequest, AppointmentModel> addAppointmentCommand,
            ICommand<AppointmentRequest, AppointmentModel> updateAppointmentCommand)
        {
            this.addAppointmentCommand = addAppointmentCommand;
            this.updateAppointmentCommand = updateAppointmentCommand;
        }

        public OperationResult<AppointmentModel> AddApointment(AppointmentRequest commandData)
        {
            return this.addAppointmentCommand.Execute(commandData);
        }

        public OperationResult<AppointmentModel> UpdateApointment(AppointmentRequest commandData)
        {
            return this.updateAppointmentCommand.Execute(commandData);
        }
    }
}
