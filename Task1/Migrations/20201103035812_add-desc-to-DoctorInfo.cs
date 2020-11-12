using Microsoft.EntityFrameworkCore.Migrations;

namespace Task1.Migrations
{
    public partial class adddesctoDoctorInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "DoctorsInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "DoctorsInfo");
        }
    }
}
