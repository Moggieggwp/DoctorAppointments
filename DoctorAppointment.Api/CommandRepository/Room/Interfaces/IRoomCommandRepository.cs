using DoctorAppointment.Api.Models.Room;
using DoctorAppointment.Api.Validators;

namespace DoctorAppointment.Api.CommandRepository.Room.Interfaces
{
    public interface IRoomCommandRepository
    {
        OperationResult<RoomModel> AddRoom(RoomRequest commandData);
        OperationResult<RoomModel> UpdateRoom(RoomRequest commandData);
    }
}
