using DoctorAppointment.Api.Commands.Interfaces;
using DoctorAppointment.Api.Models.Room;
using DoctorAppointment.Api.Services.Interfaces;
using DoctorAppointment.Api.Validators;

namespace DoctorAppointment.Api.Commands.Room
{
    public class AddRoomCommand : ICommand<RoomRequest, RoomModel>
    {
        private readonly IRoomService roomService;
        public AddRoomCommand(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        public OperationResult<RoomModel> Execute(RoomRequest commandData)
        {
            return this.roomService.AddRoom(commandData);
        }
    }
}
