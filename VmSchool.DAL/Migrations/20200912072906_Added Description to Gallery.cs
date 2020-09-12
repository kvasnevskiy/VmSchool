using Microsoft.EntityFrameworkCore.Migrations;

namespace VmSchool.DAL.Migrations
{
    public partial class AddedDescriptiontoGallery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Galleries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Galleries");
        }
    }
}
