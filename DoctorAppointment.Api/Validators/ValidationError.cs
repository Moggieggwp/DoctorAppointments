using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Api.Validators
{
    public class ValidationError
    {
        public string ErrorMessage { get; private set; }

        public ValidationError(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
        }
    }
}
