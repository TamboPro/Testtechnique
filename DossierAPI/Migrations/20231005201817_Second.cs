using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DossierAPI.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vols_Categories_CategorieId",
                table: "Vols");

            migrationBuilder.DropIndex(
                name: "IX_Vols_CategorieId",
                table: "Vols");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Vols");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategorieId",
                table: "Vols",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Vols_CategorieId",
                table: "Vols",
                column: "CategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vols_Categories_CategorieId",
                table: "Vols",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "IdCategorie",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
