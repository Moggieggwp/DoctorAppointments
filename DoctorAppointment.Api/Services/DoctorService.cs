using DoctorAppointment.Api.Models;
using DoctorAppointment.Api.Services.Interfaces;
using DoctorAppointment.Api.Validators;
using DoctorAppointment.Api.Validators.Interfaces;
using DoctorAppointment.Database.Entities;
using DoctorAppointment.Database.Repositories.Doctor.Interfaces;

namespace DoctorAppointment.Api.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorReadRepository doctorReadRepository;
        private readonly IDoctorWriteRepository doctorWriteRepository;
        private readonly IApplicationMappingService applicationMappingService;
        private readonly IValidator<DoctorModel> doctorValidator;
        public DoctorService(
            IDoctorReadRepository doctorReadRepository,
            IDoctorWriteRepository doctorWriteRepository,
            IValidator<DoctorModel> doctorValidator,
            IApplicationMappingService applicationMappingService)
        {
            this.doctorReadRepository = doctorReadRepository;
            this.doctorWriteRepository = doctorWriteRepository;
            this.applicationMappingService = applicationMappingService;
            this.doctorValidator = doctorValidator;
        }

        public OperationResult<DoctorModel> AddDoctor(DoctorRequest doctorRequest)
        {
            var doctortModel = new DoctorModel
            {
                Id = doctorRequest.Id,
                Name = doctorRequest.Name,
                Specialization = doctorRequest.Specialization,
                WorkExperience = doctorRequest.WorkExperience
            };

            OperationResult<DoctorModel> operatingResult = this.doctorValidator.Validate(doctortModel);

            if (operatingResult.IsValid)
            {
                Doctor doctor = this.doctorWriteRepository.AddDoctor(this.applicationMappingService.MapToDoctorEntity(doctortModel));
                operatingResult.Response = this.applicationMappingService.MapToDoctorModel(doctor);
            }

            return operatingResult;
        }

        public DoctorModel GetDoctorById(int id)
        {
            Database.Entities.Doctor doctor = doctorReadRepository.GetDoctorById(id);
            return this.applicationMappingService.MapToDoctorModel(doctor);
        }

        public OperationResult<DoctorModel> UpdateDoctor(DoctorRequest doctorRequest)
        {
            var doctortModel = new DoctorModel
            {
                Id = doctorRequest.Id,
                Name = doctorRequest.Name,
                Specialization = doctorRequest.Specialization,
                WorkExperience = doctorRequest.WorkExperience
            };

            OperationResult<DoctorModel> operatingResult = this.doctorValidator.Validate(doctortModel);

            if (operatingResult.IsValid)
            {
                Doctor doctor = this.doctorWriteRepository.UpdateDoctor(this.applicationMappingService.MapToDoctorEntity(doctortModel));
                operatingResult.Response = this.applicationMappingService.MapToDoctorModel(doctor);
            }

            return operatingResult;
        }
    }
}
