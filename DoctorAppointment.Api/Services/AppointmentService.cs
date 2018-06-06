using System.Collections.Generic;
using System.Linq;
using DoctorAppointment.Database.Models;
using DoctorAppointment.Api.Services.Interfaces;
using DoctorAppointment.Database.Repositories.Appointment.Interfaces;
using DoctorAppointment.Api.Validators.Interfaces;
using DoctorAppointment.Api.Validators;
using System;
using DoctorAppointment.Database.Repositories.Room.Interfaces;

namespace DoctorAppointment.Api.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentReadRepository appointmentReadRepository;
        private readonly IAppointmentWriteRepository appointmentWriteRepository;
        private readonly IRoomReadRepository roomReadRepository;
        private readonly IValidator<AppointmentModel> appointmentValidator;

        public AppointmentService(
            IAppointmentReadRepository appointmentReadRepository,
            IAppointmentWriteRepository appointmentWriteRepository,
            IValidator<AppointmentModel> appointmentValidator,
            IRoomReadRepository roomReadRepository)
        {
            this.appointmentReadRepository = appointmentReadRepository;
            this.appointmentWriteRepository = appointmentWriteRepository;
            this.appointmentValidator = appointmentValidator;
            this.roomReadRepository = roomReadRepository;
        }

        public List<AppointmentModel> GetAppointmentsByDoctorName(string doctorName)
        {
            var appointments = this.appointmentReadRepository.GetAppointmentsByDoctorName(doctorName);
            return appointments.Select(AppointmentMapper.MapToModel).ToList();
        }

        public OperationResult<AppointmentModel> AddAndReturnAppointment(AppointmentRequest appointmentRequest)
        {
            var appointmentModel = new AppointmentModel
            {
                Doctor = appointmentRequest.DoctorName,
                Duration = appointmentRequest.Duration,
                Time = appointmentRequest.Time,
                RoomNumber = appointmentRequest.RoomNumber
            };

            var operatingResult = this.appointmentValidator.Validate(appointmentModel);

            if (operatingResult.IsValid)
            {
                appointmentModel.Id = this.GetIdForAppointment();

                var appointment = this.appointmentWriteRepository.AddAndReturnAppointment(AppointmentMapper.MapToEntity(appointmentModel));
                operatingResult.Response = AppointmentMapper.MapToModel(appointment);
            }

            return operatingResult;
        }

        public OperationResult<AppointmentModel> UpdateAndReturnAppointment(AppointmentRequest appointmentRequest)
        {
            var appointmentModel = new AppointmentModel
            {
                Doctor = appointmentRequest.DoctorName,
                Duration = appointmentRequest.Duration,
                Time = appointmentRequest.Time,
                RoomNumber = appointmentRequest.RoomNumber
            };

            var operatingResult = this.appointmentValidator.Validate(appointmentModel);

            if (operatingResult.IsValid)
            {
                appointmentModel.Id = this.GetIdForAppointment();

                var appointment = this.appointmentWriteRepository.UpdateAndReturnAppointment(AppointmentMapper.MapToEntity(appointmentModel));
                operatingResult.Response = AppointmentMapper.MapToModel(appointment);
            }

            return operatingResult;
        }

        public AppointmentModel GetAppointmentById(int id)
        {
            var appointment = this.appointmentReadRepository.GetAppointmentById(id);
            return AppointmentMapper.MapToModel(appointment);
        }

        private int GetIdForAppointment()
        {
            var appointments = this.appointmentReadRepository.GetAppointments();
            var appointment = appointments.OrderByDescending(c => c.Id).First();

            return appointment.Id++;
        }
    }
}
