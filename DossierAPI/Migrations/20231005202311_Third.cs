using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DossierAPI.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vols_Compagnies_CompanieId",
                table: "Vols");

            migrationBuilder.DropIndex(
                name: "IX_Vols_CompanieId",
                table: "Vols");

            migrationBuilder.AddColumn<Guid>(
                name: "CompagnieIdCompagnie",
                table: "Vols",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vols_CompagnieIdCompagnie",
                table: "Vols",
                column: "CompagnieIdCompagnie");

            migrationBuilder.AddForeignKey(
                name: "FK_Vols_Compagnies_CompagnieIdCompagnie",
                table: "Vols",
                column: "CompagnieIdCompagnie",
                principalTable: "Compagnies",
                principalColumn: "IdCompagnie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vols_Compagnies_CompagnieIdCompagnie",
                table: "Vols");

            migrationBuilder.DropIndex(
                name: "IX_Vols_CompagnieIdCompagnie",
                table: "Vols");

            migrationBuilder.DropColumn(
                name: "CompagnieIdCompagnie",
                table: "Vols");

            migrationBuilder.CreateIndex(
                name: "IX_Vols_CompanieId",
                table: "Vols",
                column: "CompanieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vols_Compagnies_CompanieId",
                table: "Vols",
                column: "CompanieId",
                principalTable: "Compagnies",
                principalColumn: "IdCompagnie",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
