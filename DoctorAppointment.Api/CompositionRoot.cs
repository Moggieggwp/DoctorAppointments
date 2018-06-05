using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using DoctorAppointment.Api.Services;
using DoctorAppointment.Api.Validators;
using DoctorAppointment.Api.Validators.Interfaces;
using DoctorAppointment.Database.Models;
using DoctorAppointment.Database.Repositories;
using DoctorAppointment.Database.Repositories.Appointment;
using DoctorAppointment.Database.Repositories.Appointment.Interfaces;

namespace DoctorAppointment.Api
{
    /// <summary>
    /// Used to compose all known API controllers by creating and passing required dependencies.
    /// <para>Also known as "poor man's DI" since we are not using DI container and intead composing dependencies by hand.</para>
    /// </summary>
    public class CompositionRoot : IHttpControllerActivator
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["HostpitalDB"].ConnectionString;
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            if (controllerType == typeof(HomeController))
            {
                return new HomeController();
            }

            if (controllerType == typeof(AppointmentsController))
            {   
                //TODO: create and pass any dependencies to controller constructor here
                return new AppointmentsController(
                    new AppointmentService(
                        new AppointmentReadRepository(connectionString),
                        new AppointmentWriteRepository(connectionString),
                        new AppointmentValidator<AppointmentModel>(
                            new List<IAppointmentValidator<AppointmentModel>>
                            {
                                new AppointmentRequiredFieldsValidator(),
                                new AppointmentTimeRangeValidator(),
                                new AppointmentCollisionValidator(new AppointmentReadRepository(connectionString))
                            })));
            }

            throw new NotSupportedException(string.Format("Controller type {0} not supported", controllerType.FullName));
        }
    }
}
