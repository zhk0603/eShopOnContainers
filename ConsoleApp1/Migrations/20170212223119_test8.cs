using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp1.Migrations
{
    public partial class test8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_paymentmethods_buyers_PaymentMethodId",
                schema: "ordering",
                table: "paymentmethods");

            migrationBuilder.DropIndex(
                name: "IX_paymentmethods_PaymentMethodId",
                schema: "ordering",
                table: "paymentmethods");

            migrationBuilder.DropColumn(
                name: "PaymentMethodId",
                schema: "ordering",
                table: "paymentmethods");

            migrationBuilder.CreateIndex(
                name: "IX_paymentmethods_BuyerId",
                schema: "ordering",
                table: "paymentmethods",
                column: "BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_paymentmethods_buyers_BuyerId",
                schema: "ordering",
                table: "paymentmethods",
                column: "BuyerId",
                principalSchema: "ordering",
                principalTable: "buyers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_paymentmethods_buyers_BuyerId",
                schema: "ordering",
                table: "paymentmethods");

            migrationBuilder.DropIndex(
                name: "IX_paymentmethods_BuyerId",
                schema: "ordering",
                table: "paymentmethods");

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentMethodId",
                schema: "ordering",
                table: "paymentmethods",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_paymentmethods_PaymentMethodId",
                schema: "ordering",
                table: "paymentmethods",
                column: "PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_paymentmethods_buyers_PaymentMethodId",
                schema: "ordering",
                table: "paymentmethods",
                column: "PaymentMethodId",
                principalSchema: "ordering",
                principalTable: "buyers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
