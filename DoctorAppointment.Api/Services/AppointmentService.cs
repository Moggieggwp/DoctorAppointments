using System.Collections.Generic;
using System.Linq;
using DoctorAppointment.Database.Models;
using DoctorAppointment.Api.Services.Interfaces;
using DoctorAppointment.Database.Repositories.Appointment.Interfaces;
using DoctorAppointment.Api.Validators.Interfaces;
using DoctorAppointment.Api.Validators;

namespace DoctorAppointment.Api.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentReadRepository appointmentReadRepository;
        private readonly IAppointmentWriteRepository appointmentWriteRepository;
        private readonly IValidator<AppointmentModel> appointmentValidator;

        public AppointmentService(
            IAppointmentReadRepository appointmentReadRepository,
            IAppointmentWriteRepository appointmentWriteRepository,
            IValidator<AppointmentModel> appointmentValidator)
        {
            this.appointmentReadRepository = appointmentReadRepository;
            this.appointmentWriteRepository = appointmentWriteRepository;
            this.appointmentValidator = appointmentValidator;
        }

        public List<AppointmentModel> GetAppointmentsByDoctorName(string doctorName)
        {
            var appointments = this.appointmentReadRepository.GetAppointmentsByDoctorName(doctorName);
            return appointments.Select(AppointmentMapper.MapToModel).ToList();
        }

        public OperationResult<AppointmentModel> AddAndReturnAppointment(string doctorName, AppointmentRequest appointmentRequest)
        {
            var appointmentModel = new AppointmentModel
            {
                Doctor = doctorName,
                Duration = appointmentRequest.Duration,
                Time = appointmentRequest.Time
            };

            var operatingResult = this.appointmentValidator.Validate(appointmentModel);

            if (operatingResult.IsValid)
            {
                var appointment = this.appointmentWriteRepository.AddAndReturnAppointment(doctorName, appointmentRequest);
                operatingResult.Response = AppointmentMapper.MapToModel(appointment);
            }

            return operatingResult;
        }
    }
}
