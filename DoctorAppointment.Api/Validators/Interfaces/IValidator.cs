namespace DoctorAppointment.Api.Validators.Interfaces
{
    public interface IValidator<TModel>
    {
        OperationResult<TModel> Validate(TModel entity);
    }
}
