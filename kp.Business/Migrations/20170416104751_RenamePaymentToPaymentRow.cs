using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kp.Business.Migrations
{
    public partial class RenamePaymentToPaymentRow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.CreateTable(
                name: "PaymentRows",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    PaymentKindId = table.Column<Guid>(nullable: false),
                    PaymentNumber = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentRows_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentRows_PaymentKinds_PaymentKindId",
                        column: x => x.PaymentKindId,
                        principalTable: "PaymentKinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRows_ClientId",
                table: "PaymentRows",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRows_PaymentKindId",
                table: "PaymentRows",
                column: "PaymentKindId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentRows");

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    PaymentKindId = table.Column<Guid>(nullable: false),
                    PaymentNumber = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentKinds_PaymentKindId",
                        column: x => x.PaymentKindId,
                        principalTable: "PaymentKinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ClientId",
                table: "Payments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentKindId",
                table: "Payments",
                column: "PaymentKindId");
        }
    }
}
