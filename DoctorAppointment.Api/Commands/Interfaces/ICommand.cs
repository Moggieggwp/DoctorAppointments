using DoctorAppointment.Api.Validators;

namespace DoctorAppointment.Api.Commands.Interfaces
{
    public interface ICommand<TIn, TOut>
        where TIn : class
        where TOut : class
    {
        OperationResult<TOut> Execute(TIn commandData);
    }
}
