using Microsoft.EntityFrameworkCore.Migrations;

namespace Quarto.Api.EF.Migrations
{
    public partial class PopulateEnumData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO [enum.Listing.AccommodationType] (ID, Name)
VALUES 
(1, 'Room'),
(2, 'House'),
(3, 'Venue'),
(4, 'Resort'),
(5, 'Office Space')
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM [enum.Listing.AccommodationType]");
        }
    }
}
