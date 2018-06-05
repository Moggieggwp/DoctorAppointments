using System.Collections.Generic;
using System.Linq;

namespace DoctorAppointment.Api.Validators
{
    public class OperationResult<T>
    {
        public List<ValidationError> Errors { get; set; }

        public T Response { get; set; }

        public bool IsValid
        {
            get
            {
                return !this.Errors.Any();
            }
        }
    }
}
