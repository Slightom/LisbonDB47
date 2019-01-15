using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LisbonDB47.Migrations
{
    public partial class UserPoisRemovedFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_UserPois_UserPoiID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_UserPois_UserPoiID",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_UserPois_UserPoiID",
                table: "Likes");

            migrationBuilder.DropTable(
                name: "UserPois");

            migrationBuilder.DropIndex(
                name: "IX_Likes_UserPoiID",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Images_UserPoiID",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserPoiID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserPoiID",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "UserPoiID",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserPoiID",
                table: "Likes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserPoiID",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserPois",
                columns: table => new
                {
                    UserPoiID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PoiID = table.Column<int>(nullable: false),
                    Private = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPois", x => x.UserPoiID);
                    table.ForeignKey(
                        name: "FK_UserPois_Pois_PoiID",
                        column: x => x.PoiID,
                        principalTable: "Pois",
                        principalColumn: "PoiID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPois_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserPoiID",
                table: "Likes",
                column: "UserPoiID");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserPoiID",
                table: "Images",
                column: "UserPoiID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserPoiID",
                table: "Comments",
                column: "UserPoiID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPois_PoiID",
                table: "UserPois",
                column: "PoiID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPois_UserID",
                table: "UserPois",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_UserPois_UserPoiID",
                table: "Comments",
                column: "UserPoiID",
                principalTable: "UserPois",
                principalColumn: "UserPoiID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_UserPois_UserPoiID",
                table: "Images",
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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
