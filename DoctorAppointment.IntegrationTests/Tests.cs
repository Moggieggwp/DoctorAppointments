using System;
using System.Net;
using System.Net.Http;
using Ploeh.AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace DoctorAppointment.IntegrationTests
{
    public class Tests
    {
        private const string ConnectionStringName = "HostpitalDB";

        [Fact]
        public void GET_api_home_returns_OK()
        {
            using (var client = TestServerHttpClientFactory.Create())
            {
                var response = client.GetAsync("/api").Result;

                Assert.True(response.IsSuccessStatusCode, "Expected Successfull status code, but was: " + response.StatusCode);
            }
        }

        [Theory]
        [AutoData]
        [UsingDatabase(ConnectionStringName)]
        public void GET_appointments_returns_stored_appointments(Guid appointmentId, DateTimeOffset time, decimal duration, string doctorName)
        {
            var appointment = new
            {
                Id = appointmentId,
                Doctor = doctorName,
                Time = time,
                Duration = duration
            };

            // prepare the DB to have existing appointments
            var db = Simple.Data.Database.OpenNamedConnection(ConnectionStringName);
            db.Appointments.Insert(appointment);

            using (var client = TestServerHttpClientFactory.Create())
            {
                var response = client.GetAsync(String.Format("/api/doctors/{0}/appointments", doctorName)).Result;

                var json = response.ReadAsJson();
                var actual = json.appointments[0];

                new
                {
                    Id = actual.id,
                    Doctor = actual.doctor,
                    Time = actual.time,
                    Duration = actual.duration
                }.ShouldBeEquivalentTo(appointment, "because we expect api to read appointments from DB");
            }
        }

        [Theory]
        [AutoData]
        [UsingDatabase(ConnectionStringName)]
        public void POST_appointment_adds_record_to_DB_and_returns_created_appointment(
            Guid appointmentId, 
            DateTimeOffset time, 
            decimal duration, 
            string doctorName)
        {
            var appointment = new
            {
                Time = time,
                Duration = duration
            };

            var expected = new
            {
                Doctor = doctorName,
                Time = time,
                Duration = duration
            };

            using (var client = TestServerHttpClientFactory.Create())
            {
                var response = client.PostAsJsonAsync(String.Format("/api/doctors/{0}/appointments", doctorName), appointment).Result;
                response.StatusCode.Should().Be(HttpStatusCode.Created, "because we expect 201 response when creating resource with POST");

                var json = response.ReadAsJson();
                new
                {
                    Doctor = doctorName,
                    Time = json.time,
                    Duration = json.duration
                }.ShouldBeEquivalentTo(expected);

                new Action(() => new Guid(json.id.ToString())).ShouldNotThrow("because response must have a Guid Id");

                var db = Simple.Data.Database.OpenNamedConnection(ConnectionStringName);
                var dbAppointments = db.Appointments.All();
                ((int)dbAppointments.Count()).Should().Be(1, "because we expect single appointment record to be created");

                new
                {
                    Doctor = dbAppointments.First().Doctor,
                    Time = dbAppointments.First().Time,
                    Duration = dbAppointments.First().Duration
                }.ShouldBeEquivalentTo(expected, "because we expect DB to have the appointment we just created");
            }
        }
    }
}
