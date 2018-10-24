namespace DoctorAppointment.Api.Models
{
    /// <summary>
    /// represents a single doctor data retured by the api to client
    /// </summary>
    public class DoctorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WorkExperience { get; set; }
        public string Specialization { get; set; }
    }
}
