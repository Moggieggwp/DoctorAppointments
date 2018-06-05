using System.Collections.Generic;

namespace DoctorAppointment.Api.Validators.Interfaces
{
    public interface IAppointmentValidator<TModel>
    {
        List<ValidationError> Validate(TModel entity);
    }
}
