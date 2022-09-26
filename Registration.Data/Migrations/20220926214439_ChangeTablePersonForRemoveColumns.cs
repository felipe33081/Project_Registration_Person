using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registration.Data.Migrations
{
    public partial class ChangeTablePersonForRemoveColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FathersName",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "MothersName",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "Person");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Person",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "uuid_generate_v4()");

            migrationBuilder.AddColumn<decimal>(
                name: "LimitCredit",
                table: "Person",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LimitCredit",
                table: "Person");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Person",
                type: "uuid",
                nullable: false,
                defaultValueSql: "uuid_generate_v4()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "FathersName",
                table: "Person",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MothersName",
                table: "Person",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                table: "Person",
                type: "text",
                nullable: true);
        }
    }
}
