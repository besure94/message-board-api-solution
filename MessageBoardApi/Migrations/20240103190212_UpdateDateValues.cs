using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessageBoardApi.Migrations
{
    public partial class UpdateDateValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 11, 19, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 1, 3, 11, 2, 12, 91, DateTimeKind.Local).AddTicks(8111));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 1, 3, 11, 2, 12, 91, DateTimeKind.Local).AddTicks(8117));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 1, 3, 10, 49, 58, 494, DateTimeKind.Local).AddTicks(8365));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 1, 3, 10, 49, 58, 494, DateTimeKind.Local).AddTicks(8448));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 1, 3, 10, 49, 58, 494, DateTimeKind.Local).AddTicks(8536));
        }
    }
}
