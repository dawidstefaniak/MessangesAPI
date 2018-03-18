using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MessangesAPI.Migrations
{
    public partial class AddDatesNow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestString",
                table: "Users");

            migrationBuilder.AddColumn<DateTime>(
                name: "SentDate",
                table: "Messages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SentDate",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "TestString",
                table: "Users",
                maxLength: 10,
                nullable: true);
        }
    }
}
