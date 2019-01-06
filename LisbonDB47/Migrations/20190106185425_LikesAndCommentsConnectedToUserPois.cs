using Microsoft.EntityFrameworkCore.Migrations;

namespace LisbonDB47.Migrations
{
    public partial class LikesAndCommentsConnectedToUserPois : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Pois_PoiID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Pois_PoiID",
                table: "Likes");

            migrationBuilder.RenameColumn(
                name: "PoiID",
                table: "Likes",
                newName: "UserPoiID");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_PoiID",
                table: "Likes",
                newName: "IX_Likes_UserPoiID");

            migrationBuilder.RenameColumn(
                name: "PoiID",
                table: "Comments",
                newName: "UserPoiID");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_PoiID",
                table: "Comments",
                newName: "IX_Comments_UserPoiID");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_UserPois_UserPoiID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_UserPois_UserPoiID",
                table: "Likes");

            migrationBuilder.RenameColumn(
                name: "UserPoiID",
                table: "Likes",
                newName: "PoiID");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_UserPoiID",
                table: "Likes",
                newName: "IX_Likes_PoiID");

            migrationBuilder.RenameColumn(
                name: "UserPoiID",
                table: "Comments",
                newName: "PoiID");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserPoiID",
                table: "Comments",
                newName: "IX_Comments_PoiID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Pois_PoiID",
                table: "Comments",
                column: "PoiID",
                principalTable: "Pois",
                principalColumn: "PoiID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Pois_PoiID",
                table: "Likes",
                column: "PoiID",
                principalTable: "Pois",
                principalColumn: "PoiID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
