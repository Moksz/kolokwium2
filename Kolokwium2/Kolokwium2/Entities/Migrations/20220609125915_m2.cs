using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolokwium2.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MusicLabel",
                columns: new[] { "IdMusicLabel", "Name" },
                values: new object[] { 1, "label" });

            migrationBuilder.InsertData(
                table: "Musican",
                columns: new[] { "IdMusican", "FirstName", "LastName", "Nickname" },
                values: new object[] { 1, "aaa", "bbb", "ccc" });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "IdAlbum", "AlbumName", "IdMusicLabel", "PublishDate" },
                values: new object[] { 1, "aaa", 1, new DateTime(2022, 6, 9, 14, 59, 15, 99, DateTimeKind.Local).AddTicks(5994) });

            migrationBuilder.InsertData(
                table: "Track",
                columns: new[] { "IdTrack", "Duration", "IdMusicAlbum", "TrackName" },
                values: new object[] { 1, 1.5, 1, "track" });

            migrationBuilder.InsertData(
                table: "Musican_Track",
                columns: new[] { "IdMusican", "IdTrack" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Musican_Track",
                keyColumns: new[] { "IdMusican", "IdTrack" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Musican",
                keyColumn: "IdMusican",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "IdTrack",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MusicLabel",
                keyColumn: "IdMusicLabel",
                keyValue: 1);
        }
    }
}
