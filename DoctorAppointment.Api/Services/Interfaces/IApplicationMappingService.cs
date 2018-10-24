using DoctorAppointment.Api.Models;
using DoctorAppointment.Api.Models.Room;
using DoctorAppointment.Database.Entities;
using DoctorAppointment.Database.Models;

namespace DoctorAppointment.Api.Services.Interfaces
{
    public interface IApplicationMappingService
    {
        AppointmentModel MapToAppointmentModel(Appointment appointment);
        Appointment MapToAppointmentEntity(AppointmentModel appointmentModel);
        Doctor MapToDoctorEntity(DoctorModel doctorModel);
        DoctorModel MapToDoctorModel(Doctor doctorModel);
        Room MapToRoomEntity(RoomModel roomModel);
        RoomModel MapToRoomModel(Room roomModel);
        AppointmentResponse MergeToAppointmentResponse(Appointment appointment, Doctor doctor, Room room);
    }
}
