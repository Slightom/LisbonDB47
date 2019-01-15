using Microsoft.EntityFrameworkCore.Migrations;

namespace LisbonDB47.Migrations
{
    public partial class UserPoisRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_UserPois_UserPoiID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_UserPois_UserPoiID",
                table: "Likes");

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
                name: "UserPoiID",
                table: "PathPois");

            migrationBuilder.DropColumn(
                name: "Private",
                table: "Images");

            migrationBuilder.AddColumn<bool>(
                name: "Private",
                table: "Pois",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Pois",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PoiID",
                table: "PathPois",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserPoiID",
                table: "Likes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PoiID",
                table: "Likes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PoiID",
                table: "Images",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserPoiID",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PoiID",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pois_UserID",
                table: "Pois",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PoiID",
                table: "Likes",
                column: "PoiID");

            migrationBuilder.CreateIndex(
                name: "IX_Images_PoiID",
                table: "Images",
                column: "PoiID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PoiID",
                table: "Comments",
                column: "PoiID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Pois_PoiID",
                table: "Comments",
                column: "PoiID",
                principalTable: "Pois",
                principalColumn: "PoiID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_UserPois_UserPoiID",
                table: "Comments",
                column: "UserPoiID",
                principalTable: "UserPois",
                principalColumn: "UserPoiID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Pois_PoiID",
                table: "Images",
                column: "PoiID",
                principalTable: "Pois",
                principalColumn: "PoiID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Pois_PoiID",
                table: "Likes",
                column: "PoiID",
                principalTable: "Pois",
                principalColumn: "PoiID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_UserPois_UserPoiID",
                table: "Likes",
                column: "UserPoiID",
                principalTable: "UserPois",
                principalColumn: "UserPoiID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PathPois_Pois_PoiID",
                table: "PathPois",
                column: "PoiID",
                principalTable: "Pois",
                principalColumn: "PoiID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pois_Users_UserID",
                table: "Pois",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Pois_PoiID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_UserPois_UserPoiID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Pois_PoiID",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Pois_PoiID",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_UserPois_UserPoiID",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_PathPois_Pois_PoiID",
                table: "PathPois");

            migrationBuilder.DropForeignKey(
                name: "FK_Pois_Users_UserID",
                table: "Pois");

            migrationBuilder.DropIndex(
                name: "IX_Pois_UserID",
                table: "Pois");

            migrationBuilder.DropIndex(
                name: "IX_Likes_PoiID",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Images_PoiID",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PoiID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Private",
                table: "Pois");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Pois");

            migrationBuilder.DropColumn(
                name: "PoiID",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "PoiID",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "PoiID",
                table: "Comments");

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

            migrationBuilder.AlterColumn<int>(
                name: "UserPoiID",
                table: "Likes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Private",
                table: "Images",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "UserPoiID",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PathPois_UserPoiID",
                table: "PathPois",
                column: "UserPoiID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_UserPois_UserPoiID",
                table: "Comments",
                column: "UserPoiID",
                principalTable: "UserPois",
                principalColumn: "UserPoiID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_UserPois_UserPoiID",
                table: "Likes",
                column: "UserPoiID",
                principalTable: "UserPois",
                principalColumn: "UserPoiID",
                onDelete: ReferentialAction.Cascade);

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
    }
}
