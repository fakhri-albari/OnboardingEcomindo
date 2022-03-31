using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnboardingEcomindo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FCashier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FCashier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Stock = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CashierId = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<int>(nullable: false),
                    TotalQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FTransaction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FDetailTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FDetailTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FDetailTransaction_FTransaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "FTransaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FDetailTransaction_TransactionId",
                table: "FDetailTransaction",
                column: "TransactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FCashier");

            migrationBuilder.DropTable(
                name: "FDetailTransaction");

            migrationBuilder.DropTable(
                name: "FItem");

            migrationBuilder.DropTable(
                name: "FTransaction");
        }
    }
}
