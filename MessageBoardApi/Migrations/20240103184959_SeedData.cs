using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessageBoardApi.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Author", "Date", "Group", "UserMessage" },
                values: new object[,]
                {
                    { 1, "newbieDrummer99", new DateTime(2024, 1, 3, 10, 49, 58, 494, DateTimeKind.Local).AddTicks(8365), "Music Makers", "Best drum kit for a beginner?" },
                    { 2, "gamerchick", new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Local), "PC Gamers", "Favorite loadout for Overwatch?" },
                    { 3, "nightryder82", new DateTime(2024, 1, 3, 10, 49, 58, 494, DateTimeKind.Local).AddTicks(8448), "Cycling Enthusiasts", "Looking for rain-resistant tires for my bike" },
                    { 4, "muddyB00tz", new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Local), "Hiking fanatics", "Best hiking trails in Cascade mountain range?" },
                    { 5, "StampNerd", new DateTime(2024, 1, 3, 10, 49, 58, 494, DateTimeKind.Local).AddTicks(8536), "Stamp collectors", "Can someone tell me the year of this stamp?" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 5);
        }
    }
}
