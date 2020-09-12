using Microsoft.EntityFrameworkCore.Migrations;

namespace VmSchool.DAL.Migrations
{
    public partial class AddpathtoGallery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Galleries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Galleries");
        }
    }
}
