using Microsoft.EntityFrameworkCore.Migrations;

namespace Quarto.Api.EF.Migrations
{
    public partial class Populate_AvailabilityType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO [enum.Listing.AvailabilityType] (ID, Name)
VALUES 
(1, 'Vacant'),
(2, 'Occupied'),
(3, 'Not Available')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM [enum.Listing.AvailabilityType]");
        }
    }
}
