using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_ManagementSystem.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeinDoctorSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSchedule_Doctors_DoctorId",
                table: "DoctorSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorSchedule",
                table: "DoctorSchedule");

            migrationBuilder.RenameTable(
                name: "DoctorSchedule",
                newName: "DoctorSchedules");

            migrationBuilder.RenameColumn(
                name: "DateAndTime",
                table: "Appointments",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "DoctorSchedules",
                newName: "Date");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorSchedule_DoctorId",
                table: "DoctorSchedules",
                newName: "IX_DoctorSchedules_DoctorId");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "Appointments",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "DoctorSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "DoctorSchedules",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorSchedules",
                table: "DoctorSchedules",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicationDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DoctorId",
                table: "Prescriptions",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientId",
                table: "Prescriptions",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSchedules_Doctors_DoctorId",
                table: "DoctorSchedules",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSchedules_Doctors_DoctorId",
                table: "DoctorSchedules");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorSchedules",
                table: "DoctorSchedules");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "DoctorSchedules");

            migrationBuilder.RenameTable(
                name: "DoctorSchedules",
                newName: "DoctorSchedule");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Appointments",
                newName: "DateAndTime");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "DoctorSchedule",
                newName: "DateTime");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorSchedules_DoctorId",
                table: "DoctorSchedule",
                newName: "IX_DoctorSchedule_DoctorId");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "DoctorSchedule",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorSchedule",
                table: "DoctorSchedule",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSchedule_Doctors_DoctorId",
                table: "DoctorSchedule",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }
    }
}
