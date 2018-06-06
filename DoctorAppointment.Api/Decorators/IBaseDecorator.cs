using log4net;

namespace DoctorAppointment.Api.Decorators
{
    public interface IBaseDecorator
    {
        ILog Logger { get; set; }
    }
}
