namespace DoctorAppointment.Api.Models.Room
{
    /// <summary>
    /// represents a single room data retured by the api to client
    /// </summary>
    public class RoomModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Occupancy { get; set; }
    }
}
