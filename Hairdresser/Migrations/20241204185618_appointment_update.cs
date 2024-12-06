using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hairdresser.Migrations
{
    /// <inheritdoc />
    public partial class appointment_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_customers_customerID",
                table: "appointments");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "appointmentHour",
                table: "appointments",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "customerName",
                table: "appointments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "serviceName",
                table: "appointments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_AspNetUsers_customerID",
                table: "appointments",
                column: "customerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_AspNetUsers_customerID",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "appointmentHour",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "customerName",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "serviceName",
                table: "appointments");

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    customerID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customerEmail = table.Column<string>(type: "text", nullable: true),
                    customerName = table.Column<string>(type: "text", nullable: true),
                    customerPassword = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.customerID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_customers_customerID",
                table: "appointments",
                column: "customerID",
                principalTable: "customers",
                principalColumn: "customerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
