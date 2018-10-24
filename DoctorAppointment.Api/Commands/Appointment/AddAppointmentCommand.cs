using DoctorAppointment.Api.Commands.Interfaces;
using DoctorAppointment.Api.Models;
using DoctorAppointment.Api.Services.Interfaces;
using DoctorAppointment.Api.Validators;
using DoctorAppointment.Database.Models;

namespace DoctorAppointment.Api.Commands.Appointment
{
    public class AddAppointmentCommand : ICommand<AppointmentRequest, AppointmentModel>
    {
        private readonly IAppointmentService appointmentService;
        public AddAppointmentCommand(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }
        
        public OperationResult<AppointmentModel> Execute(AppointmentRequest commandData)
        {
            return this.appointmentService.AddAppointment(commandData);
        }
    }
}
