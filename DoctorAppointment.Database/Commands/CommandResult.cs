using System.Collections.Generic;

namespace DoctorAppointment.Database.Commands
{
    public class CommandResult<T>
    {
        public IEnumerable<T> Data { get; set; }
        public bool IsSuccess { get; set; }
    }
}
