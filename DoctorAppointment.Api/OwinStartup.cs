using System.Web.Http;
using System.Web.Http.Dispatcher;
using Owin;
using Microsoft.Owin.Cors;

namespace DoctorAppointment.Api
{
    /// <summary>
    /// Can be used to configure OWIN Web API application
    /// </summary>
    public class OwinStartup
    {
        private static void ConfigureRoutes(HttpConfiguration configuration)
        {
            configuration.MapHttpAttributeRoutes();
        }

        private static void ConfigureServices(HttpConfiguration configuration, IHttpControllerActivator activator)
        {
            configuration.Services.Replace(typeof(IHttpControllerActivator), activator);
        }

        private static void ConfigureFormatting(HttpConfiguration configuration)
        {
            configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
        }

        private static void Configure(HttpConfiguration configuration, IHttpControllerActivator activator)
        {
            ConfigureRoutes(configuration);
            ConfigureServices(configuration, activator);
            ConfigureFormatting(configuration);
        }

        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            app.UseCors(CorsOptions.AllowAll);

            var composition = new CompositionRoot();
            Configure(config, composition);

            app.UseWebApi(config);
        }
    }
}
