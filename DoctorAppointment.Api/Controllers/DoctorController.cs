using DoctorAppointment.Api.Decorators.Doctors.Interfaces;
using DoctorAppointment.Api.Models;
using DoctorAppointment.Api.Services.Interfaces;
using DoctorAppointment.Api.Validators;
using System.Web.Http;

namespace DoctorAppointment.Api.Controllers
{
    [RoutePrefix("api/doctor")]
    public class DoctorController : BaseController
    {
        private readonly IDoctorService doctorService;
        private readonly IDoctorDecorator doctorDecorator;

        public DoctorController(
            IDoctorService doctorService,
            IDoctorDecorator doctorDecorator)
        {
            this.doctorService = doctorService;
            this.doctorDecorator = doctorDecorator;
        }

        /// <summary>
        /// gets doctor by id
        /// </summary>
        /// <param name="doctorId">the id of doctor</param>
        /// <returns>doctor wrapped in <see cref="DoctorModel"/></returns>
        [Route]
        public IHttpActionResult GetDoctorById(int doctorId)
        {
            return this.ExecuteApplicationServiceMethod<int, DoctorModel>(
                "GetDoctorById",
                doctorId,
                this.doctorService.GetDoctorById);
        }

        /// <summary>
        /// creats a new doctor
        /// </summary>
        /// <param name="appRequest">doctor data</param>
        /// <returns>created doctor wrapped in <see cref="AppointmentModel"/></returns>
        [Route]
        public IHttpActionResult AddDoctor(DoctorRequest appRequest)
        {
            return this.ExecuteApplicationServiceMethod<DoctorRequest, OperationResult<DoctorModel>>(
                "AddDoctor",
                appRequest,
                this.doctorDecorator.AddDoctor);
        }

        /// <summary>
        /// updates an doctor 
        /// </summary>
        /// <param name="appRequest">doctor data</param>
        /// <returns>created doctor wrapped in <see cref="AppointmentModel"/></returns>
        [Route]
        public IHttpActionResult UpdateDoctor(DoctorRequest appRequest)
        {
            return this.ExecuteApplicationServiceMethod<DoctorRequest, OperationResult<DoctorModel>>(
                "UpdateDoctor",
                appRequest,
                this.doctorDecorator.UpdateDoctor);
        }
    }
}
