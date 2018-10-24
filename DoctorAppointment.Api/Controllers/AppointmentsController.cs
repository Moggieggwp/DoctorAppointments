using System.Collections.Generic;
using System.Web.Http;
using DoctorAppointment.Api.Controllers;
using DoctorAppointment.Api.Decorators.Interfaces;
using DoctorAppointment.Api.Models;
using DoctorAppointment.Api.Services.Interfaces;
using DoctorAppointment.Api.Validators;
using DoctorAppointment.Database.Models;

namespace DoctorAppointment.Api
{
    [RoutePrefix("api/appointment")]
    public class AppointmentsController : BaseController
    {
        private readonly IAppointmentService appointmentService;
        private readonly IAppointmentDecorator appointmentDecorator;

        public AppointmentsController(
            IAppointmentService appointmentService,
            IAppointmentDecorator appointmentDecorator)
        {
            this.appointmentService = appointmentService;
            this.appointmentDecorator = appointmentDecorator;
        }

        /// <summary>
        /// gets all appointments that given doctor has
        /// </summary>
        /// <param name="doctorName">the name of the doctor to get appointments for</param>
        /// <returns>lis of doctor appointments wrapped in <see cref="AppointmentsResponse"/></returns>
        [Route]
        public IHttpActionResult GetAppointmentsByDoctorId(int doctorId)
        {
            return this.ExecuteApplicationServiceMethod<int, List<AppointmentResponse>>(
                "GetAppointmentsByDoctorName",
                doctorId,
                this.appointmentService.GetAppointmentsByDoctorId);
        }

        /// <summary>
        /// creats a new appointment for the doctor
        /// </summary>
        /// <param name="appRequest">appointment data</param>
        /// <returns>created appointment wrapped in <see cref="AppointmentModel"/></returns>
        [Route]
        public IHttpActionResult AddAppointment(AppointmentRequest appRequest)
        {
            return this.ExecuteApplicationServiceMethod<AppointmentRequest, OperationResult<AppointmentModel>>(
                "AddAppointment",
                appRequest,
                this.appointmentDecorator.AddAppointment);
        }

        /// <summary>
        /// updates an appointment for the doctor
        /// </summary>
        /// <param name="appRequest">appointment data</param>
        /// <returns>created appointment wrapped in <see cref="AppointmentModel"/></returns>
        [Route]
        public IHttpActionResult UpdateAppointment(AppointmentRequest appRequest)
        {
            return this.ExecuteApplicationServiceMethod<AppointmentRequest, OperationResult<AppointmentModel>>(
                "UpdateAppointment",
                appRequest,
                this.appointmentDecorator.UpdateAppointment);
        }

        /// <summary>
        /// gets appointment by id
        /// </summary>
        /// <param name="appointmentId">the id of appointment</param>
        /// <returns>appointment wrapped in <see cref="AppointmentModel"/></returns>
        [Route]
        public IHttpActionResult GetAppointmentById(int appointmentId)
        {
            return this.ExecuteApplicationServiceMethod<int, AppointmentResponse>(
                "GetAppointmentById",
                appointmentId,
                this.appointmentService.GetAppointmentById);
        }
    }
}
