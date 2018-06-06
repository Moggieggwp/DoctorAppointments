using System.Collections.Generic;

namespace DoctorAppointment.Database.Repositories.Room.Interfaces
{
    public interface IRoomReadRepository
    {
        Entities.Room GetRoomById(int id);

        List<Entities.Room> GetAvailableRooms();
    }
}
