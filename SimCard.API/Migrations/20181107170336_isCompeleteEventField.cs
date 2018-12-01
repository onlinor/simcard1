﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace simcard.api.Migrations
{
    public partial class isCompeleteEventField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isCompleteEvent",
                table: "Events",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isCompleteEvent",
                table: "Events");
        }
    }
}
