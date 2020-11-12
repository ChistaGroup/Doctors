using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Task1.Migrations
{
    public partial class GenerateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorsInfo",
                columns: table => new
                {
                    DoctorID = table.Column<int>(nullable: false),
                    Row = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Family = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(type: "image", nullable: true),
                    OfficeImage = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    MyProperty = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorsInfo", x => x.DoctorID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorsInfo");
        }
    }
}
