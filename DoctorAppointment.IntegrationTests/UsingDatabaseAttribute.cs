using System.Configuration;
using DoctorAppointment.Database;
using Xunit.Sdk;

namespace DoctorAppointment.IntegrationTests
{
    /// <summary>
    /// Marks a test method as test that involves DB usage. 
    /// Test DB is migrated to latest schema before the test starts to run.
    /// After the test finished executing, DB schema is rolled back to "clean" initial state. 
    /// <para>Test author can be sure that DB will have no "dirty" data at the beginning of test</para>
    /// <para>Any data written to DB in the scope of the test will be lost.</para>
    /// </summary>
    public class UsingDatabaseAttribute : BeforeAfterTestAttribute
    {
        private string _connString;

        public UsingDatabaseAttribute(string connStringName)
        {
            _connString = ConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
        }

        public override void Before(System.Reflection.MethodInfo methodUnderTest)
        {
            MigrationsRunner.MigrateToLatestVersion(_connString);

            base.Before(methodUnderTest);
        }

        public override void After(System.Reflection.MethodInfo methodUnderTest)
        {
            MigrationsRunner.MigrateDownToCleanDb(_connString);

            base.After(methodUnderTest);
        }
    }
}
