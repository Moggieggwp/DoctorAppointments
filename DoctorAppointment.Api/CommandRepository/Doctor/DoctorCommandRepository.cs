using DoctorAppointment.Api.CommandRepository.Doctor.Interfaces;
using DoctorAppointment.Api.Commands.Interfaces;
using DoctorAppointment.Api.Models;
using DoctorAppointment.Api.Validators;

namespace DoctorAppointment.Api.CommandRepository.Doctor
{
    class DoctorCommandRepository : IDoctorCommandRepository
    {
        private readonly ICommand<DoctorRequest, DoctorModel> addDoctorCommand;
        private readonly ICommand<DoctorRequest, DoctorModel> updateDoctorCommand;

        public DoctorCommandRepository(
             ICommand<DoctorRequest, DoctorModel> addDoctorCommand,
             ICommand<DoctorRequest, DoctorModel> updateDoctorCommand)
        {
            this.addDoctorCommand = addDoctorCommand;
            this.updateDoctorCommand = updateDoctorCommand;
        }

        public OperationResult<DoctorModel> AddDoctor(DoctorRequest commandData)
        {
            return this.addDoctorCommand.Execute(commandData);
        }

        public OperationResult<DoctorModel> UpdateDoctor(DoctorRequest commandData)
        {
            return this.updateDoctorCommand.Execute(commandData);
        }
    }
}
