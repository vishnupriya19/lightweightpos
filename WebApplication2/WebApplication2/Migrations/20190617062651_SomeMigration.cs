using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class SomeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    ticketId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    merchantid = table.Column<int>(nullable: false),
                    employeeId = table.Column<int>(nullable: false),
                    customerId = table.Column<int>(nullable: true),
                    totalCost = table.Column<double>(nullable: false),
                    orderDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => new { x.ticketId, x.merchantid });
                });

            migrationBuilder.CreateTable(
                name: "TicketLineProduct",
                columns: table => new
                {
                    ticketId = table.Column<long>(nullable: false),
                    productId = table.Column<int>(nullable: false),
                    merchantId = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    price = table.Column<double>(nullable: false),
                    totalPrice = table.Column<double>(nullable: false),
                    commission = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketLineProduct", x => new { x.ticketId, x.productId, x.merchantId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "TicketLineProduct");
        }
    }
}
