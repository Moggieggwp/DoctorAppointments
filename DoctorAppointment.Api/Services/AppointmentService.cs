using System.Collections.Generic;
using System.Linq;
using DoctorAppointment.Database.Models;
using DoctorAppointment.Api.Services.Interfaces;
using DoctorAppointment.Database.Repositories.Appointment.Interfaces;
using DoctorAppointment.Api.Validators.Interfaces;
using DoctorAppointment.Api.Validators;
using DoctorAppointment.Database.Repositories.Room.Interfaces;
using DoctorAppointment.Api.Models;
using DoctorAppointment.Database.Repositories.Doctor.Interfaces;
using DoctorAppointment.Database.Entities;

namespace DoctorAppointment.Api.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentReadRepository appointmentReadRepository;
        private readonly IAppointmentWriteRepository appointmentWriteRepository;
        private readonly IRoomReadRepository roomReadRepository;
        private readonly IDoctorReadRepository doctorReadRepository;
        private readonly IValidator<AppointmentModel> appointmentValidator;
        private readonly IApplicationMappingService applicationMappingService;

        public AppointmentService(
            IAppointmentReadRepository appointmentReadRepository,
            IAppointmentWriteRepository appointmentWriteRepository,
            IValidator<AppointmentModel> appointmentValidator,
            IRoomReadRepository roomReadRepository,
            IDoctorReadRepository doctorReadRepository,
            IApplicationMappingService applicationMappingService)
        {
            this.appointmentReadRepository = appointmentReadRepository;
            this.appointmentWriteRepository = appointmentWriteRepository;
            this.appointmentValidator = appointmentValidator;
            this.roomReadRepository = roomReadRepository;
            this.doctorReadRepository = doctorReadRepository;
            this.applicationMappingService = applicationMappingService;
        }

        public List<AppointmentResponse> GetAppointmentsByDoctorId(int doctorId)
        {
            var appintmentsList = new List<AppointmentResponse>();
            List<Appointment> appointments = this.appointmentReadRepository.GetAppointmentsByDoctorId(doctorId);

            foreach (Appointment appointment in appointments)
            {
                Room room = this.roomReadRepository.GetRoomById(appointment.RoomId);
                Doctor doctor = this.doctorReadRepository.GetDoctorById(appointment.DoctorId);

                appintmentsList.Add(this.applicationMappingService.MergeToAppointmentResponse(appointment, doctor, room));
            }

            return appintmentsList;
        }

        public OperationResult<AppointmentModel> AddAppointment(AppointmentRequest appointmentRequest)
        {
            var appointmentModel = new AppointmentModel
            {
                DoctorId = appointmentRequest.DoctorId,
                Duration = appointmentRequest.Duration,
                Time = appointmentRequest.Time,
                RoomId = appointmentRequest.RoomId
            };

            OperationResult<AppointmentModel> operatingResult = this.appointmentValidator.Validate(appointmentModel);

            if (operatingResult.IsValid)
            {
                appointmentModel.Id = this.GetIdForAppointment();

                Appointment appointment = this.appointmentWriteRepository.AddAppointment(this.applicationMappingService.MapToAppointmentEntity(appointmentModel));
                operatingResult.Response = this.applicationMappingService.MapToAppointmentModel(appointment);
            }

            return operatingResult;
        }

        public OperationResult<AppointmentModel> UpdateAppointment(AppointmentRequest appointmentRequest)
        {
            var appointmentModel = new AppointmentModel
            {
                DoctorId = appointmentRequest.DoctorId,
                Duration = appointmentRequest.Duration,
                Time = appointmentRequest.Time,
                RoomId = appointmentRequest.RoomId
            };

            OperationResult<AppointmentModel> operatingResult = this.appointmentValidator.Validate(appointmentModel);

            if (operatingResult.IsValid)
            {
                appointmentModel.Id = this.GetIdForAppointment();

                Appointment appointment = this.appointmentWriteRepository.UpdateAppointment(this.applicationMappingService.MapToAppointmentEntity(appointmentModel));
                operatingResult.Response = this.applicationMappingService.MapToAppointmentModel(appointment);
            }

            return operatingResult;
        }

        public AppointmentResponse GetAppointmentById(int id)
        {
            Appointment appointment = this.appointmentReadRepository.GetAppointmentById(id);
            Room room = this.roomReadRepository.GetRoomById(appointment.RoomId);
            Doctor doctor = this.doctorReadRepository.GetDoctorById(appointment.DoctorId);

            return this.applicationMappingService.MergeToAppointmentResponse(appointment, doctor, room);
        }

        private int GetIdForAppointment()
        {
            List<Appointment> appointments = this.appointmentReadRepository.GetAppointments();
            Appointment appointment = appointments.OrderByDescending(c => c.Id).First();

            return appointment.Id++;
        }
    }
}
