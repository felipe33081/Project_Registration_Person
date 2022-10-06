using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Registration.Data.Migrations
{
    public partial class InitilMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Código = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AddressName = table.Column<string>(type: "text", nullable: true),
                    ZipCode = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    UF = table.Column<int>(type: "integer", nullable: true),
                    District = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<string>(type: "text", nullable: true),
                    Complement = table.Column<string>(type: "text", nullable: true),
                    Criado_Em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Atualizado_Em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Criado_Por = table.Column<string>(type: "text", nullable: true),
                    Atualizado_Por = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Código);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Código = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descrição = table.Column<string>(type: "text", nullable: false),
                    Preço = table.Column<string>(type: "text", nullable: false),
                    Categoria = table.Column<int>(type: "integer", nullable: true),
                    Criado_Em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Atualizado_Em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Criado_Por = table.Column<string>(type: "text", nullable: true),
                    Atualizado_Por = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Código);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    Código = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "text", nullable: false),
                    AddressId = table.Column<int>(type: "integer", nullable: true),
                    Criado_Em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Atualizado_Em = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Criado_Por = table.Column<string>(type: "text", nullable: true),
                    Atualizado_Por = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.Código);
                    table.ForeignKey(
                        name: "FK_Provider_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Código");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Provider_AddressId",
                table: "Provider",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
