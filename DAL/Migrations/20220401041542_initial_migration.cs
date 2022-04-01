using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnboardingEcomindo.DAL.Migrations
{
    public partial class initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FCashier",
                columns: table => new
                {
                    CashierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FCashier", x => x.CashierId);
                });

            migrationBuilder.CreateTable(
                name: "FItem",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FItem", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "FTransaction",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false),
                    CashierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FTransaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_FTransaction_FCashier_CashierId",
                        column: x => x.CashierId,
                        principalTable: "FCashier",
                        principalColumn: "CashierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FDetailTransaction",
                columns: table => new
                {
                    DetailTransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FDetailTransaction", x => x.DetailTransactionId);
                    table.ForeignKey(
                        name: "FK_FDetailTransaction_FItem_ItemId",
                        column: x => x.ItemId,
                        principalTable: "FItem",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FDetailTransaction_FTransaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "FTransaction",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FDetailTransaction_ItemId",
                table: "FDetailTransaction",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_FDetailTransaction_TransactionId",
                table: "FDetailTransaction",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_FTransaction_CashierId",
                table: "FTransaction",
                column: "CashierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FDetailTransaction");

            migrationBuilder.DropTable(
                name: "FItem");

            migrationBuilder.DropTable(
                name: "FTransaction");

            migrationBuilder.DropTable(
                name: "FCashier");
        }
    }
}
