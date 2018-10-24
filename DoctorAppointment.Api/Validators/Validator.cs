using System.Collections.Generic;
using System.Linq;
using DoctorAppointment.Api.Validators.Interfaces;

namespace DoctorAppointment.Api.Validators
{
    public class Validator<TModel> : IValidator<TModel> where TModel : class
    {
        private List<IListValidator<TModel>> validators;

        public Validator(List<IListValidator<TModel>> validators)
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


