using DoctorAppointment.Api.CommandRepository.Doctor.Interfaces;
using DoctorAppointment.Api.Decorators.Doctors.Interfaces;
using DoctorAppointment.Api.Models;
using DoctorAppointment.Api.Validators;
using System;

namespace DoctorAppointment.Api.Decorators.Doctors
{
    public class DoctorDecorator : BaseDecorator, IDoctorDecorator
    {
        private readonly IDoctorCommandRepository doctorCommandRepository;

        public DoctorDecorator(IDoctorCommandRepository doctorCommandRepository)
        {
            this.doctorCommandRepository = doctorCommandRepository;
        }

        public OperationResult<DoctorModel> AddDoctor(DoctorRequest commandData)
        {
            try
            {
                this.Logger.Debug("Execution of AddDoctor command");
                return this.doctorCommandRepository.AddDoctor(commandData);
            }
            catch (Exception ex)
            {
                this.Logger.Error($"Error during execution of AddDoctor command: {ex.ToString()}");
                throw;
            }
        }

        public OperationResult<DoctorModel> UpdateDoctor(DoctorRequest commandData)
        {
            try
            {
                this.Logger.Debug("Execution of UpdateDoctor command");
                return this.doctorCommandRepository.UpdateDoctor(commandData);
            }
            catch (Exception ex)
            {
                this.Logger.Error($"Error during execution of UpdateDoctor command: {ex.ToString()}");
                throw;
            }
        }
    }
}
