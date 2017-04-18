using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kp.Business.Migrations
{
    public partial class ReworkPayments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_PaymentRows_PaymentRowId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "PaymentKinds");

            migrationBuilder.DropColumn(
                name: "PaymentNumber",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "PaymentRowId",
                table: "Payments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_PaymentRowId",
                table: "Payments",
                newName: "IX_Payments_UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Payments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentKindId",
                table: "Payments",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentRowEntityId",
                table: "Payments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Payments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "Payments",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentKindId",
                table: "Payments",
                column: "PaymentKindId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentRowEntityId",
                table: "Payments",
                column: "PaymentRowEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_PaymentKinds_PaymentKindId",
                table: "Payments",
                column: "PaymentKindId",
                principalTable: "PaymentKinds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_PaymentRows_PaymentRowEntityId",
                table: "Payments",
                column: "PaymentRowEntityId",
                principalTable: "PaymentRows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Clients_UserId",
                table: "Payments",
                column: "UserId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_PaymentKinds_PaymentKindId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_PaymentRows_PaymentRowEntityId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Clients_UserId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_PaymentKindId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_PaymentRowEntityId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentKindId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentRowEntityId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Payments",
                newName: "PaymentRowId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                newName: "IX_Payments_PaymentRowId");

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "PaymentKinds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentNumber",
                table: "Payments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_PaymentRows_PaymentRowId",
                table: "Payments",
                column: "PaymentRowId",
                principalTable: "PaymentRows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
