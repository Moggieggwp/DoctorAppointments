using DoctorAppointment.Api.Commands.Interfaces;
using DoctorAppointment.Api.Models;
using DoctorAppointment.Api.Services.Interfaces;
using DoctorAppointment.Api.Validators;

namespace DoctorAppointment.Api.Commands.Doctor
{
    public class AddDoctorCommand : ICommand<DoctorRequest, DoctorModel>
    {
        private readonly IDoctorService doctorService;
        public AddDoctorCommand(IDoctorService doctorService)
        {
            this.doctorService = doctorService;
        }

        public OperationResult<DoctorModel> Execute(DoctorRequest commandData)
        {
            return this.doctorService.AddDoctor(commandData);
        }
    }
}
