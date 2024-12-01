using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hairdresser.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    adminID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    adminEmail = table.Column<string>(type: "text", nullable: true),
                    adminPassword = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.adminID);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    customerID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customerName = table.Column<string>(type: "text", nullable: true),
                    customerEmail = table.Column<string>(type: "text", nullable: true),
                    customerPassword = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.customerID);
                });

            migrationBuilder.CreateTable(
                name: "expertises",
                columns: table => new
                {
                    expertiseID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    expertiseName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expertises", x => x.expertiseID);
                });

            migrationBuilder.CreateTable(
                name: "salons",
                columns: table => new
                {
                    salonID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    salonName = table.Column<string>(type: "text", nullable: true),
                    salonType = table.Column<string>(type: "text", nullable: true),
                    workingHours = table.Column<string>(type: "text", nullable: true),
                    salonAddress = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salons", x => x.salonID);
                });

            migrationBuilder.CreateTable(
                name: "personnels",
                columns: table => new
                {
                    personnelID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    personnelName = table.Column<string>(type: "text", nullable: true),
                    availableHours = table.Column<string>(type: "text", nullable: true),
                    salonID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personnels", x => x.personnelID);
                    table.ForeignKey(
                        name: "FK_personnels_salons_salonID",
                        column: x => x.salonID,
                        principalTable: "salons",
                        principalColumn: "salonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    serviceID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    serviceName = table.Column<string>(type: "text", nullable: true),
                    serviceDuration = table.Column<int>(type: "integer", nullable: false),
                    servicePrice = table.Column<decimal>(type: "numeric", nullable: false),
                    salonID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.serviceID);
                    table.ForeignKey(
                        name: "FK_services_salons_salonID",
                        column: x => x.salonID,
                        principalTable: "salons",
                        principalColumn: "salonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpertisePersonnel",
                columns: table => new
                {
                    expertisesexpertiseID = table.Column<int>(type: "integer", nullable: false),
                    personnelspersonnelID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertisePersonnel", x => new { x.expertisesexpertiseID, x.personnelspersonnelID });
                    table.ForeignKey(
                        name: "FK_ExpertisePersonnel_expertises_expertisesexpertiseID",
                        column: x => x.expertisesexpertiseID,
                        principalTable: "expertises",
                        principalColumn: "expertiseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpertisePersonnel_personnels_personnelspersonnelID",
                        column: x => x.personnelspersonnelID,
                        principalTable: "personnels",
                        principalColumn: "personnelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    appointmentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    appointmentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    customerID = table.Column<int>(type: "integer", nullable: false),
                    personnelID = table.Column<int>(type: "integer", nullable: false),
                    serviceID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.appointmentID);
                    table.ForeignKey(
                        name: "FK_appointments_customers_customerID",
                        column: x => x.customerID,
                        principalTable: "customers",
                        principalColumn: "customerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_personnels_personnelID",
                        column: x => x.personnelID,
                        principalTable: "personnels",
                        principalColumn: "personnelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_services_serviceID",
                        column: x => x.serviceID,
                        principalTable: "services",
                        principalColumn: "serviceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_customerID",
                table: "appointments",
                column: "customerID");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_personnelID",
                table: "appointments",
                column: "personnelID");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_serviceID",
                table: "appointments",
                column: "serviceID");

            migrationBuilder.CreateIndex(
                name: "IX_ExpertisePersonnel_personnelspersonnelID",
                table: "ExpertisePersonnel",
                column: "personnelspersonnelID");

            migrationBuilder.CreateIndex(
                name: "IX_personnels_salonID",
                table: "personnels",
                column: "salonID");

            migrationBuilder.CreateIndex(
                name: "IX_services_salonID",
                table: "services",
                column: "salonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "ExpertisePersonnel");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.DropTable(
                name: "expertises");

            migrationBuilder.DropTable(
                name: "personnels");

            migrationBuilder.DropTable(
                name: "salons");
        }
    }
}
