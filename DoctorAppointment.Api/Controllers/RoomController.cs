using DoctorAppointment.Api.Decorators.Rooms.Interfaces;
using DoctorAppointment.Api.Models.Room;
using DoctorAppointment.Api.Services.Interfaces;
using DoctorAppointment.Api.Validators;
using System.Web.Http;

namespace DoctorAppointment.Api.Controllers
{
    [RoutePrefix("api/room")]
    public class RoomController : BaseController
    {
        private readonly IRoomService roomService;
        private readonly IRoomDecorator roomDecorator;

        public RoomController(
            IRoomService roomService,
            IRoomDecorator roomDecorator)
        {
            this.roomService = roomService;
            this.roomDecorator = roomDecorator;
        }

        /// <summary>
        /// gets Room by id
        /// </summary>
        /// <param name="doctorId">the id of doctor</param>
        /// <returns>doctor wrapped in <see cref="RoomModel"/></returns>
        [Route]
        public IHttpActionResult GetRoomById(int doctorId)
        {
            return this.ExecuteApplicationServiceMethod<int, RoomModel>(
                "GetRoomById",
                doctorId,
                this.roomService.GetRoomById);
        }

        /// <summary>
        /// creats a new doctor
        /// </summary>
        /// <param name="appRequest">doctor data</param>
        /// <returns>created doctor wrapped in <see cref="AppointmentModel"/></returns>
        [Route]
        public IHttpActionResult AddRoom(RoomRequest appRequest)
        {
            return this.ExecuteApplicationServiceMethod<RoomRequest, OperationResult<RoomModel>>(
                "AddRoom",
                appRequest,
                this.roomDecorator.AddRoom);
        }

        /// <summary>
        /// updates an doctor 
        /// </summary>
        /// <param name="appRequest">doctor data</param>
        /// <returns>created doctor wrapped in <see cref="AppointmentModel"/></returns>
        [Route]
        public IHttpActionResult UpdateRoom(RoomRequest appRequest)
        {
            return this.ExecuteApplicationServiceMethod<RoomRequest, OperationResult<RoomModel>>(
                "UpdateRoom",
                appRequest,
                this.roomDecorator.UpdateRoom);
        }
    }
}
