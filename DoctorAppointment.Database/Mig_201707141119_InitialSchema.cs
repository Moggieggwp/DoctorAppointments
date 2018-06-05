using FluentMigrator;

namespace DoctorAppointment.Database
{
    /// <summary>
    /// Creates the initial schema of doctor appointmen api database
    /// </summary>
    [Migration(201707141119)]
    public class Mig_201707141119_InitialSchema : Migration
    {
        public override void Down()
        {
            Delete.Table("Appointments").InSchema("dbo");
        }

        public override void Up()
        {
            Create.Table("Appointments").InSchema("dbo")
                    .WithColumn("Id").AsGuid().PrimaryKey()
                    .WithColumn("Doctor").AsString(100).NotNullable()
                    .WithColumn("Time").AsDateTimeOffset().NotNullable()
                    .WithColumn("Duration").AsDecimal().NotNullable();
        }
    }
}
