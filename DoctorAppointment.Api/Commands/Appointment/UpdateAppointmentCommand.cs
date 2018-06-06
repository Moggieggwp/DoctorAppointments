using DoctorAppointment.Api.Commands.Interfaces;
using DoctorAppointment.Api.Services.Interfaces;
using DoctorAppointment.Api.Validators;
using DoctorAppointment.Database.Models;

namespace DoctorAppointment.Api.Commands.Appointment
{
    public class UpdateAppointmentCommand : ICommand<AppointmentRequest, AppointmentModel>
    {
        private readonly IAppointmentService appointmentService;
        public UpdateAppointmentCommand(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        public OperationResult<AppointmentModel> Execute(AppointmentRequest commandData)
        {
            return this.appointmentService.UpdateAndReturnAppointment(commandData);
        }
    }
}
