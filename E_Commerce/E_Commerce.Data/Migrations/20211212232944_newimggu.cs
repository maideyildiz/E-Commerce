using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce.Data.Migrations
{
    public partial class newimggu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Products",
                newName: "PictureURL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PictureURL",
                table: "Products",
                newName: "ImageURL");
        }
    }
}
