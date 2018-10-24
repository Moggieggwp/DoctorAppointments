namespace DoctorAppointment.Database.Repositories.Room.Interfaces
{
    public interface IRoomWriteRepository
    {
        Entities.Room AddRoom(Entities.Room room);
        Entities.Room UpdateRoom(Entities.Room room);
    }
}
