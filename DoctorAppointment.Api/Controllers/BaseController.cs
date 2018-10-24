using log4net;
using System;
using System.Net;
using System.Web.Http;

namespace DoctorAppointment.Api.Controllers
{
    public class BaseController : ApiController
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BaseController()
        {
        }

        public IHttpActionResult ExecuteApplicationServiceMethod<TRequestData, TResultData>(
            string commandName,
            TRequestData request,
            Func<TRequestData, TResultData> commandExecute
            )
        {
            try
            {
                Logger.Debug($"Start executing {commandName}");
                TResultData result = commandExecute(request);
                Logger.Debug($"Executing of {commandName} is finished succesfully");
                return this.Content(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                Logger.Error($"Executing of {commandName} is finished with unhandled error: {ex.ToString()}");
                return this.BadRequest(ex.Message);
            }
        }
    }
}
