using DoctorAppointment.Api.Models;
using DoctorAppointment.Api.Models.Room;
using DoctorAppointment.Api.Services.Interfaces;
using DoctorAppointment.Database.Entities;
using DoctorAppointment.Database.Models;

namespace DoctorAppointment.Api.Services
{
    public class ApplicationMappingService : IApplicationMappingService
    {
        public AppointmentModel MapToAppointmentModel(Appointment appointment)
        {
            return new AppointmentModel
            {
                Id = appointment.Id,
                DoctorId = appointment.DoctorId,
                Time = appointment.Time,
                Duration = appointment.Duration
            };
        }

        public Appointment MapToAppointmentEntity(AppointmentModel appointmentModel)
        {
            return new Appointment
            {
                Id = appointmentModel.Id,
                DoctorId = appointmentModel.DoctorId,
                Time = appointmentModel.Time,
                Duration = appointmentModel.Duration
            };
        }

        public Doctor MapToDoctorEntity(DoctorModel doctorModel)
        {
            return new Doctor
            {
                Id = doctorModel.Id,
                Name = doctorModel.Name,
                Specialization = doctorModel.Specialization,
                WorkExperience = doctorModel.WorkExperience
            };
        }

        public DoctorModel MapToDoctorModel(Doctor doctorModel)
        {
            return new DoctorModel
            {
                Id = doctorModel.Id,
                Name = doctorModel.Name,
                Specialization = doctorModel.Specialization,
                WorkExperience = doctorModel.WorkExperience
            };
        }

        public AppointmentResponse MergeToAppointmentResponse(Appointment appointment, Doctor doctor, Room room)
        {
            return new AppointmentResponse
            {
                Id = appointment.Id,
                Duration = appointment.Duration,
                Time = appointment.Time,
                Doctor = new DoctorModel
                {
                    Id = doctor.Id,
                    Name = doctor.Name,
                    Specialization = doctor.Specialization,
                    WorkExperience = doctor.WorkExperience
                },
                Room = new RoomModel
                {
                    Id = room.Id,
                    Name = room.Name,
                    Occupancy = room.Occupancy
                }
            };
        }

        public Room MapToRoomEntity(RoomModel roomModel)
        {
            throw new System.NotImplementedException();
        }

        public RoomModel MapToRoomModel(Room roomModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
