using System.Net.Http;
using DoctorAppointment.Api;
using Microsoft.Owin.Testing;

namespace DoctorAppointment.IntegrationTests
{
    /// <summary>
    /// Uses OWIN test server to host api under test and creats http client for that server
    /// </summary>
    public static class TestServerHttpClientFactory
    {
        /// <summary>
        /// Creates test server http client that can be used for api integration tests
        /// </summary>
        public static HttpClient Create()
        {
            var server = TestServer.Create(app => new OwinStartup().Configuration(app));
            var client = server.HttpClient;
            return client;
        }
    }
}
