using DoctorAppointment.Api.Models.Room;
using DoctorAppointment.Api.Validators;

namespace DoctorAppointment.Api.Services.Interfaces
{
    public interface IRoomService
    {
        RoomModel GetRoomById(int id);

        OperationResult<RoomModel> AddRoom(RoomRequest appointmentRequest);

        OperationResult<RoomModel> UpdateRoom(RoomRequest appointmentRequest);
    }
}
