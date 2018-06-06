using System;
using DoctorAppointment.Api.CommandRepository.Interfaces;
using DoctorAppointment.Api.Decorators.Interfaces;
using DoctorAppointment.Api.Validators;
using DoctorAppointment.Database.Models;

namespace DoctorAppointment.Api.Decorators.Appointments
{
    public class AppointmentDecorator : BaseDecorator, IAppointmentDecorator
    {
        private readonly IAppointmentCommandRepository appointmentCommandRepository;

        public AppointmentDecorator(IAppointmentCommandRepository appointmentCommandRepository)
        {
            this.appointmentCommandRepository = appointmentCommandRepository;
        }

        public OperationResult<AppointmentModel> AddAppointment(AppointmentRequest commandData)
        {
            try
            {
                this.Logger.Debug("Execution of AddAppointment command");
                return this.appointmentCommandRepository.AddApointment(commandData);
            }
            catch (Exception ex)
            {
                this.Logger.Error($"Error during execution of AddAppointment command: {ex.ToString()}");
                throw;
            }
        }

        public OperationResult<AppointmentModel> UpdateAppointment(AppointmentRequest commandData)
        {
            try
            {
                this.Logger.Debug("Execution of UpdateAppointment command");
                return this.appointmentCommandRepository.UpdateApointment(commandData);
            }
            catch (Exception ex)
            {
                this.Logger.Error($"Error during execution of UpdateAppointment command: {ex.ToString()}");
                throw;
            }
        }
    }
}
