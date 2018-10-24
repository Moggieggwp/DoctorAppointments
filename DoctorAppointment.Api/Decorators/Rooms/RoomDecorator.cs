using DoctorAppointment.Api.CommandRepository.Room.Interfaces;
using DoctorAppointment.Api.Decorators.Rooms.Interfaces;
using DoctorAppointment.Api.Models.Room;
using DoctorAppointment.Api.Validators;
using System;

namespace DoctorAppointment.Api.Decorators.Rooms
{
    public class RoomDecorator : BaseDecorator, IRoomDecorator
    {
        private readonly IRoomCommandRepository roomCommandRepository;

        public RoomDecorator(IRoomCommandRepository roomCommandRepository)
        {
            this.roomCommandRepository = roomCommandRepository;
        }

        public OperationResult<RoomModel> AddRoom(RoomRequest commandData)
        {
            try
            {
                this.Logger.Debug("Execution of AddRoom command");
                return this.roomCommandRepository.AddRoom(commandData);
            }
            catch (Exception ex)
            {
                this.Logger.Error($"Error during execution of AddRoom command: {ex.ToString()}");
                throw;
            }
        }

        public OperationResult<RoomModel> UpdateRoom(RoomRequest commandData)
        {
            try
            {
                this.Logger.Debug("Execution of UpdateRoom command");
                return this.roomCommandRepository.UpdateRoom(commandData);
            }
            catch (Exception ex)
            {
                this.Logger.Error($"Error during execution of UpdateRoom command: {ex.ToString()}");
                throw;
            }
        }
    }
}
