using DoctorAppointment.Database.Repositories.Base;
using DoctorAppointment.Database.Repositories.Room.Interfaces;

namespace DoctorAppointment.Database.Repositories
{
    public class RoomReadRepository : BaseRepository<Entities.Room>, IRoomReadRepository
    {
        private readonly string connectionString;

        public RoomReadRepository(string connectionString) : base(connectionString)
        {
            this.connectionString = connectionString;
        }

        public Entities.Room GetRoomById(int id)
        {
            return this.GetById(id, Tables.Rooms);
        }
    }
}
