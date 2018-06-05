using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace DoctorAppointment.IntegrationTests
{
    public static class ContentExtentions
    {
        /// <summary>
        /// Reads http content as json
        /// </summary>
        /// <returns>parsed json in a form of dynamic object</returns>
        public static dynamic ReadAsJson(this HttpResponseMessage response)
        {
            var str = response.Content.ReadAsStringAsync().Result;
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException("Response did not contain any json content. Status Code was: " + response.StatusCode);
            }

            return JsonConvert.DeserializeObject(str);
        }
    }
}
