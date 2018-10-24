using DoctorAppointment.Api.Commands.Interfaces;
using DoctorAppointment.Api.Models.Room;
using DoctorAppointment.Api.Services.Interfaces;
using DoctorAppointment.Api.Validators;

namespace DoctorAppointment.Api.Commands.Room
{
    public class UpdateRoomCommand : ICommand<RoomRequest, RoomModel>
    {
        private readonly IRoomService roomService;
        public UpdateRoomCommand(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        public OperationResult<RoomModel> Execute(RoomRequest commandData)
        {
            return this.roomService.UpdateRoom(commandData);
        }
    }
}
