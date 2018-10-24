using DoctorAppointment.Database.Commands;
using DoctorAppointment.Database.Repositories.Base;
using DoctorAppointment.Database.Repositories.Room.Interfaces;

namespace DoctorAppointment.Database.Repositories.Room
{
    public class RoomWriteRepository : BaseRepository<Entities.Room>, IRoomWriteRepository
    {
        private readonly string connectionString;

        public RoomWriteRepository(string connectionString) : base(connectionString)
        {
            this.connectionString = connectionString;
        }

        public Entities.Room AddRoom(Entities.Room room)
        {
            this.ExecuteCommand(new Command
            {
                Query = "insert into Rooms (Id, Name, Occupancy) values (@id, @name, @occupancy)",
                Parametrs = new { Id = room.Id, Name = room.Name, Occupancy = room.Occupancy },
                CommandType = CommandType.Insert
            });

            return this.GetById(room.Id, Tables.Rooms);
        }

        public Entities.Room UpdateRoom(Entities.Room room)
        {
            this.ExecuteCommand(new Command
            {
                Query = "update Appointments set Name = @name, Occupancy = @occupancy where Id = @id",
                Parametrs = new { Id = room.Id, Name = room.Name, Occupancy = room.Occupancy },
                CommandType = CommandType.Update
            });

            return this.GetById(room.Id, Tables.Rooms);
        }
    }
}
