using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LisbonDB47.Migrations
{
    public partial class binaryimagesaddeddatesedited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "longitude",
                table: "Pois",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "latitude",
                table: "Pois",
                newName: "Latitude");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "UserPois",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Pois",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEdited",
                table: "Paths",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "PathPois",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEdited",
                table: "Comments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "UserPois");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Pois");

            migrationBuilder.DropColumn(
                name: "DateEdited",
                table: "Paths");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "PathPois");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "DateEdited",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Pois",
                newName: "longitude");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "Pois",
                newName: "latitude");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Images",
                nullable: true);
        }
    }
}
