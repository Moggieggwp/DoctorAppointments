using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DoctorAppointment.Api
{
    [RoutePrefix("api")]
    public class HomeController : ApiController
    {
        /// <summary>
        /// API home
        /// </summary>
        /// <returns>welcome text with API version</returns>
        [Route]
        public IHttpActionResult Get()
        {
            return this.ResponseMessage(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("Welcome to doctor appointments api v.1.0")
            });
        }
    }
}
