using Microsoft.EntityFrameworkCore.Migrations;

namespace VmSchool.DAL.Migrations
{
    public partial class RemovethumbnailpathfromGallery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailPath",
                table: "Galleries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThumbnailPath",
                table: "Galleries",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
