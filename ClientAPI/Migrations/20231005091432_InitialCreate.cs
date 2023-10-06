using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClientAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IdClient = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Adresse = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IdClient);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "IdClient", "Adresse", "DateNaissance", "Email", "Nom", "Prenom" },
                values: new object[,]
                {
                    { new Guid("800e8c07-cbab-4e73-9535-9c0df16fdde0"), "Yaounde Nkolbisson", new DateTime(2023, 10, 5, 10, 14, 32, 93, DateTimeKind.Local).AddTicks(4460), "g.nfongyele@gmail.com", "tambo", "Gédéon" },
                    { new Guid("a53ebe29-2923-43f1-b486-f66ec90a89c3"), "Douala Logbessou", new DateTime(2023, 10, 5, 10, 14, 32, 93, DateTimeKind.Local).AddTicks(4473), "innovalab237@gmail.com", "tambo", "Gédéon" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
