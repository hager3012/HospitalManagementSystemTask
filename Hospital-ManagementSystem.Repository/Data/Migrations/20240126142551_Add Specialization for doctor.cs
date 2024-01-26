﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_ManagementSystem.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSpecializationfordoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Patient_PatientId",
                table: "Records");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "Records",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Patient_PatientId",
                table: "Records",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Patient_PatientId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Doctors");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "Records",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Patient_PatientId",
                table: "Records",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id");
        }
    }
}
