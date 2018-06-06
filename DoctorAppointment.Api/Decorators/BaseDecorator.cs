using log4net;

namespace DoctorAppointment.Api.Decorators
{
    public abstract class BaseDecorator : IBaseDecorator
    {
        public ILog Logger { get; set; }

        public BaseDecorator()
        {
            this.Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }
    }
}
