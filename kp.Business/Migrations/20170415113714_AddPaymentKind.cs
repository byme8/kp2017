using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kp.Business.Migrations
{
    public partial class AddPaymentKind : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PaymentKindId",
                table: "Payments",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "PaymentNumber",
                table: "Payments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PaymentKinds",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Period = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentKinds", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentKindId",
                table: "Payments",
                column: "PaymentKindId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_PaymentKinds_PaymentKindId",
                table: "Payments",
                column: "PaymentKindId",
                principalTable: "PaymentKinds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_PaymentKinds_PaymentKindId",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "PaymentKinds");

            migrationBuilder.DropIndex(
                name: "IX_Payments_PaymentKindId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentKindId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentNumber",
                table: "Payments");
        }
    }
}
