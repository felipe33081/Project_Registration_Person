using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registration.Data.Migrations
{
    public partial class ChangeTablePerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentExpiration",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "DocumentIssuanceDate",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "DocumentIssuer",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "DocumentNumber",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Phone2",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PlaceOfBirthCountry",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PlaceOfBirthState",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ResidenceType",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Workplace",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "RegistrationNumber",
                table: "Person",
                newName: "TaxNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaxNumber",
                table: "Person",
                newName: "RegistrationNumber");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DocumentExpiration",
                table: "Person",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DocumentIssuanceDate",
                table: "Person",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentIssuer",
                table: "Person",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentNumber",
                table: "Person",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DocumentType",
                table: "Person",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone2",
                table: "Person",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlaceOfBirthCountry",
                table: "Person",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlaceOfBirthState",
                table: "Person",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResidenceType",
                table: "Person",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Workplace",
                table: "Person",
                type: "text",
                nullable: true);
        }
    }
}
