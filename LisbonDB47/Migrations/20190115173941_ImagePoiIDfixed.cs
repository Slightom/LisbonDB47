using Microsoft.EntityFrameworkCore.Migrations;

namespace LisbonDB47.Migrations
{
    public partial class ImagePoiIDfixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Pois_PoiID",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "UserPoiID",
                table: "Images");

            migrationBuilder.AlterColumn<int>(
                name: "PoiID",
                table: "Images",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Pois_PoiID",
                table: "Images",
                column: "PoiID",
                principalTable: "Pois",
                principalColumn: "PoiID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Pois_PoiID",
                table: "Images");

            migrationBuilder.AlterColumn<int>(
                name: "PoiID",
                table: "Images",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UserPoiID",
                table: "Images",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Pois_PoiID",
                table: "Images",
                column: "PoiID",
                principalTable: "Pois",
                principalColumn: "PoiID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
