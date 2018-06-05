using System.Collections.Generic;
using System.Linq;
using DoctorAppointment.Api.Validators.Interfaces;

namespace DoctorAppointment.Api.Validators
{
    public class AppointmentValidator<TModel> : IValidator<TModel> where TModel : class
    {
        private List<IAppointmentValidator<TModel>> validators;

        public AppointmentValidator(List<IAppointmentValidator<TModel>> validators)
        {
            this.validators = validators;
        }

        public OperationResult<TModel> Validate(TModel entity)
        {
            var operationResults = new OperationResult<TModel>();

            var validationResults = validators.SelectMany(validator => validator.Validate(entity)).ToList();
            operationResults.Errors.AddRange(validationResults);

            return operationResults;
        }
    }
}


