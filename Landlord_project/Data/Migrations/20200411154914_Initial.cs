using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Landlord_project.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Residence",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estate = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    RentalPrice = table.Column<decimal>(type: "decimal(6, 2)", nullable: false),
                    Rooms = table.Column<int>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    FloorNumber = table.Column<int>(nullable: false),
                    CanRental = table.Column<bool>(nullable: false),
                    ShowFrom = table.Column<DateTime>(nullable: false),
                    ShowTo = table.Column<DateTime>(nullable: false),
                    ApplicationFrom = table.Column<DateTime>(nullable: false),
                    TypeOfResidence = table.Column<int>(nullable: false),
                    Area = table.Column<string>(nullable: true),
                    DateBuilt = table.Column<DateTime>(nullable: false),
                    DateRenovated = table.Column<DateTime>(nullable: false),
                    Featured = table.Column<bool>(nullable: false),
                    ImageName = table.Column<string>(nullable: true),
                    ImageFile = table.Column<byte[]>(nullable: true),
                    ImageMimeType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residence", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(7, 2)", nullable: false),
                    HasResidence = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResidenceAssignments",
                columns: table => new
                {
                    TenantID = table.Column<int>(nullable: false),
                    ResidenceID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidenceAssignments", x => new { x.ResidenceID, x.TenantID });
                    table.ForeignKey(
                        name: "FK_ResidenceAssignments_Residence_ResidenceID",
                        column: x => x.ResidenceID,
                        principalTable: "Residence",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidenceAssignments_Tenants_TenantID",
                        column: x => x.TenantID,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResidenceAssignments_TenantID",
                table: "ResidenceAssignments",
                column: "TenantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResidenceAssignments");

            migrationBuilder.DropTable(
                name: "Residence");

            migrationBuilder.DropTable(
                name: "Tenants");
        }
    }
}
