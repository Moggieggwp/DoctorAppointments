using DoctorAppointment.Api.Models.Room;
using DoctorAppointment.Api.Services.Interfaces;
using DoctorAppointment.Api.Validators;
using DoctorAppointment.Api.Validators.Interfaces;
using DoctorAppointment.Database.Entities;
using DoctorAppointment.Database.Repositories.Room.Interfaces;
using System;

namespace DoctorAppointment.Api.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomReadRepository roomReadRepository;
        private readonly IRoomWriteRepository roomWriteRepository;
        private readonly IValidator<RoomModel> roomValidator;
        private readonly IApplicationMappingService applicationMappingService;
        public RoomService(
            IRoomReadRepository roomReadRepository,
            IRoomWriteRepository roomWriteRepository,
            IValidator<RoomModel> roomValidator,
            IApplicationMappingService applicationMappingService)
        {
            this.roomReadRepository = roomReadRepository;
            this.roomWriteRepository = roomWriteRepository;
            this.applicationMappingService = applicationMappingService;
            this.roomValidator = roomValidator;
        }

        public OperationResult<RoomModel> AddRoom(RoomRequest roomRequest)
        {
            var roomModel = new RoomModel
            {
                Id = roomRequest.Id,
                Name = roomRequest.Name,
                Occupancy = roomRequest.Occupancy
            };

            OperationResult<RoomModel> operatingResult = this.roomValidator.Validate(roomModel);

            if (operatingResult.IsValid)
            {
                Room room = this.roomWriteRepository.AddRoom(this.applicationMappingService.MapToRoomEntity(roomModel));
                operatingResult.Response = this.applicationMappingService.MapToRoomModel(room);
            }

            return operatingResult;
        }

        public RoomModel GetRoomById(int id)
        {
            Database.Entities.Room room = roomReadRepository.GetRoomById(id);
            return this.applicationMappingService.MapToRoomModel(room);
        }

        public OperationResult<RoomModel> UpdateRoom(RoomRequest roomRequest)
        {
            var roomModel = new RoomModel
            {
                Id = roomRequest.Id,
                Name = roomRequest.Name,
                Occupancy = roomRequest.Occupancy
            };

            OperationResult<RoomModel> operatingResult = this.roomValidator.Validate(roomModel);

            if (operatingResult.IsValid)
            {
                Room room = this.roomWriteRepository.UpdateRoom(this.applicationMappingService.MapToRoomEntity(roomModel));
                operatingResult.Response = this.applicationMappingService.MapToRoomModel(room);
            }

            return operatingResult;
        }
    }
}
