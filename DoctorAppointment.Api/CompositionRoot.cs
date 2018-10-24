using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using DoctorAppointment.Api.CommandRepository;
using DoctorAppointment.Api.CommandRepository.Doctor;
using DoctorAppointment.Api.CommandRepository.Room;
using DoctorAppointment.Api.Commands.Appointment;
using DoctorAppointment.Api.Commands.Doctor;
using DoctorAppointment.Api.Commands.Room;
using DoctorAppointment.Api.Controllers;
using DoctorAppointment.Api.Decorators.Appointments;
using DoctorAppointment.Api.Decorators.Doctors;
using DoctorAppointment.Api.Decorators.Rooms;
using DoctorAppointment.Api.Models;
using DoctorAppointment.Api.Models.Room;
using DoctorAppointment.Api.Services;
using DoctorAppointment.Api.Validators;
using DoctorAppointment.Api.Validators.Doctor;
using DoctorAppointment.Api.Validators.Interfaces;
using DoctorAppointment.Api.Validators.Rooms;
using DoctorAppointment.Database.Models;
using DoctorAppointment.Database.Repositories;
using DoctorAppointment.Database.Repositories.Doctor;
using DoctorAppointment.Database.Repositories.Room;

namespace DoctorAppointment.Api
{
    /// <summary>
    /// Used to compose all known API controllers by creating and passing required dependencies.
    /// <para>Also known as "poor man's DI" since we are not using DI container and intead composing dependencies by hand.</para>
    /// </summary>
    public class CompositionRoot : IHttpControllerActivator
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["AppointmentDB"].ConnectionString;
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {            
            if (controllerType == typeof(AppointmentsController))
            {
                var appointmentService = new AppointmentService(
                        new AppointmentReadRepository(connectionString),
                        new AppointmentWriteRepository(connectionString),
                        new Validator<AppointmentModel>(
                            new List<IListValidator<AppointmentModel>>
                            {
                                new AppointmentRequiredFieldsValidator(),
                                new AppointmentTimeRangeValidator(),
                                new AppointmentCollisionValidator(new AppointmentReadRepository(connectionString), new ApplicationMappingService()),
                                new AppointmentRoomAvailableValidator(new AppointmentReadRepository(connectionString),new ApplicationMappingService())
                            }),
                        new RoomReadRepository(connectionString),
                        new DoctorReadRepository(connectionString),
                        new ApplicationMappingService());

                return new AppointmentsController(
                    appointmentService,
                    new AppointmentDecorator(
                        new AppointmentCommandRepository(
                            new AddAppointmentCommand(appointmentService),
                            new UpdateAppointmentCommand(appointmentService))));
            }

            if (controllerType == typeof(RoomController))
            {
                var roomService = new RoomService(
                        new RoomReadRepository(connectionString),
                        new RoomWriteRepository(connectionString),
                        new Validator<RoomModel>(
                            new List<IListValidator<RoomModel>>
                            {
                                new RoomRequiredFieldsValidator()
                            }),
                        new ApplicationMappingService());

                return new RoomController(
                    roomService,
                    new RoomDecorator(
                        new RoomCommandRepository(
                            new AddRoomCommand(roomService),
                            new UpdateRoomCommand(roomService))));
            }

            if (controllerType == typeof(DoctorController))
            {
                var doctorService = new DoctorService(
                        new DoctorReadRepository(connectionString),
                        new DoctorWriteRepository(connectionString),
                        new Validator<DoctorModel>(
                            new List<IListValidator<DoctorModel>>
                            {
                                new DoctorRequiredFieldsValidator()
                            }),
                        new ApplicationMappingService());

                return new DoctorController(
                    doctorService,
                    new DoctorDecorator(
                        new DoctorCommandRepository(
                            new AddDoctorCommand(doctorService),
                            new UpdateDoctorCommand(doctorService))));
            }

            throw new NotSupportedException(string.Format("Controller type {0} not supported", controllerType.FullName));
        }
    }
}
