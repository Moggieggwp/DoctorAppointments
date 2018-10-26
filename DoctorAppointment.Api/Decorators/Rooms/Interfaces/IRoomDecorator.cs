using DoctorAppointment.Api.Models.Room;
using DoctorAppointment.Api.Validators;

namespace DoctorAppointment.Api.Decorators.Rooms.Interfaces
{
    public interface IRoomDecorator : IBaseDecorator
    {
        OperationResult<RoomModel> AddRoom(RoomRequest commandData);
        OperationResult<RoomModel> UpdateRoom(RoomRequest commandData);
    }
}
