using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp1.Migrations
{
    public partial class test6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_buyers_FullName",
                schema: "ordering",
                table: "buyers");

            migrationBuilder.CreateIndex(
                name: "IX_buyers_FullName",
                schema: "ordering",
                table: "buyers",
                column: "FullName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_buyers_FullName",
                schema: "ordering",
                table: "buyers");

            migrationBuilder.CreateIndex(
                name: "IX_buyers_FullName",
                schema: "ordering",
                table: "buyers",
                column: "FullName",
                unique: true);
        }
    }
}
