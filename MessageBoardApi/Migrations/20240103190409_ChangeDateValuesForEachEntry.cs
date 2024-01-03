using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessageBoardApi.Migrations
{
    public partial class ChangeDateValuesForEachEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2019, 12, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(1988, 6, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 1, 3, 11, 2, 12, 91, DateTimeKind.Local).AddTicks(8111));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 1, 3, 11, 2, 12, 91, DateTimeKind.Local).AddTicks(8117));
        }
    }
}
