namespace DoctorAppointment.Database.Commands
{
    public class Command
    {
        public string Query { get; set; }
        public object Parametrs { get; set; }
        public CommandType CommandType { get; set; }
    }
}
