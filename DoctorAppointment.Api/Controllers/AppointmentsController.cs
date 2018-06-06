using System;
using System.Net;
using System.Web.Http;
using DoctorAppointment.Api.CommandRepository.Interfaces;
using DoctorAppointment.Api.Commands.Interfaces;
using DoctorAppointment.Api.Decorators.Interfaces;
using DoctorAppointment.Api.Services.Interfaces;
using DoctorAppointment.Database.Models;
using log4net;

namespace DoctorAppointment.Api
{
    [RoutePrefix("api/doctors/{doctorName}/appointments")]
    public class AppointmentsController : ApiController
    {
        private readonly IAppointmentService appointmentService;
        private readonly IAppointmentDecorator appointmentDecorator;
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
        public IHttpActionResult Get(string doctorName)
        {
            try
            {
                Logger.Debug("Get appointments by doctor name");
                var appointments = this.appointmentService.GetAppointmentsByDoctorName(doctorName);
                return this.Content(
                    HttpStatusCode.OK, appointments);
            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message);
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// creats a new appointment for the doctor
        /// </summary>
        /// <param name="doctorName">the name of the doctor to create appointment for</param>
        /// <param name="appRequest">appointment data</param>
        /// <param name="roomNumber">room data</param>
        /// <returns>created appointment wrapped in <see cref="AppointmentModel"/></returns>
        [Route]
        public IHttpActionResult Post(AppointmentRequest appRequest)
        {
            try
            {
                var addedAppointment = this.appointmentDecorator.AddAppointment(appRequest);
                return this.Content(HttpStatusCode.Created, addedAppointment);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// gets appointment by id
        /// </summary>
        /// <param name="appointmentId">the id of appointment</param>
        /// <returns>appointment wrapped in <see cref="AppointmentModel"/></returns>
        [Route]
        public IHttpActionResult GetAppointmentById(int appointmentId)
        {
            try
            {
                Logger.Debug("Get appointment by id");
                var appointment = this.appointmentService.GetAppointmentById(appointmentId);
                return this.Content(HttpStatusCode.Found, appointment);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return this.BadRequest(ex.Message);
            }
        }
    }
}
