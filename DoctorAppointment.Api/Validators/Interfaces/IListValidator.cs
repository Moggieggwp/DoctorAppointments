using System.Collections.Generic;

namespace DoctorAppointment.Api.Validators.Interfaces
{
    public interface IListValidator<TModel>
    {
        List<ValidationError> Validate(TModel entity);
    }
}
