using DoctorAppointment.Api.CommandRepository.Room.Interfaces;
using DoctorAppointment.Api.Commands.Interfaces;
using DoctorAppointment.Api.Models.Room;
using DoctorAppointment.Api.Validators;

namespace DoctorAppointment.Api.CommandRepository.Room
{
    class RoomCommandRepository : IRoomCommandRepository
    {
        private readonly ICommand<RoomRequest, RoomModel> addRoomCommand;
        private readonly ICommand<RoomRequest, RoomModel> updateRoomCommand;

        public RoomCommandRepository(
            ICommand<RoomRequest, RoomModel> addRoomCommand,
            ICommand<RoomRequest, RoomModel> updateRoomCommand)
        {
            this.addRoomCommand = addRoomCommand;
            this.updateRoomCommand = updateRoomCommand;
        }

        public OperationResult<RoomModel> AddRoom(RoomRequest commandData)
        {
            return this.addRoomCommand.Execute(commandData);
        }

        public OperationResult<RoomModel> UpdateRoom(RoomRequest commandData)
        {
            return this.updateRoomCommand.Execute(commandData);
        }
    }
}
