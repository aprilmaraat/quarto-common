using Microsoft.EntityFrameworkCore.Migrations;

namespace Quarto.Api.EF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "enum.Listing.AccommodationType",
                columns: table => new
                {
                    ID = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enum.Listing.AccommodationType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "enum.Listing.AvailabilityType",
                columns: table => new
                {
                    ID = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enum.Listing.AvailabilityType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Listing.Data",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ParentListing = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    AccomodationTypeID = table.Column<byte>(type: "tinyint", nullable: false),
                    AvailabilityTypeID = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listing.Data", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Listing.Data__enum.Listing.AccommodationType",
                        column: x => x.AccomodationTypeID,
                        principalTable: "enum.Listing.AccommodationType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Listing.Data__enum.Listing.AvailabilityType",
                        column: x => x.AvailabilityTypeID,
                        principalTable: "enum.Listing.AvailabilityType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Listing.Data_AccomodationTypeID",
                table: "Listing.Data",
                column: "AccomodationTypeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Listing.Data_AvailabilityTypeID",
                table: "Listing.Data",
                column: "AvailabilityTypeID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Listing.Data");

            migrationBuilder.DropTable(
                name: "enum.Listing.AccommodationType");

            migrationBuilder.DropTable(
                name: "enum.Listing.AvailabilityType");
        }
    }
}
