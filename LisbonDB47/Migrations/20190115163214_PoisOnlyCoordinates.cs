using Microsoft.EntityFrameworkCore.Migrations;

namespace LisbonDB47.Migrations
{
    public partial class PoisOnlyCoordinates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PathPois_Pois_PoiID",
                table: "PathPois");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "UserPois",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "UserPois",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PoiID",
                table: "PathPois",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UserPoiID",
                table: "PathPois",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PathPois_UserPoiID",
                table: "PathPois",
                column: "UserPoiID");

            migrationBuilder.AddForeignKey(
                name: "FK_PathPois_Pois_PoiID",
                table: "PathPois",
                column: "PoiID",
                principalTable: "Pois",
                principalColumn: "PoiID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PathPois_UserPois_UserPoiID",
                table: "PathPois",
                column: "UserPoiID",
                principalTable: "UserPois",
                principalColumn: "UserPoiID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PathPois_Pois_PoiID",
                table: "PathPois");

            migrationBuilder.DropForeignKey(
                name: "FK_PathPois_UserPois_UserPoiID",
                table: "PathPois");

            migrationBuilder.DropIndex(
                name: "IX_PathPois_UserPoiID",
                table: "PathPois");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "UserPois");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "UserPois");

            migrationBuilder.DropColumn(
                name: "UserPoiID",
                table: "PathPois");

            migrationBuilder.AlterColumn<int>(
                name: "PoiID",
                table: "PathPois",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PathPois_Pois_PoiID",
                table: "PathPois",
                column: "PoiID",
                principalTable: "Pois",
                principalColumn: "PoiID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
