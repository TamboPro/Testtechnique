using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DossierAPI.Migrations
{
    /// <inheritdoc />
    public partial class Five : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billets_Vols_VolId",
                table: "Billets");

            migrationBuilder.DropIndex(
                name: "IX_Billets_VolId",
                table: "Billets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Billets_VolId",
                table: "Billets",
                column: "VolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Billets_Vols_VolId",
                table: "Billets",
                column: "VolId",
                principalTable: "Vols",
                principalColumn: "IdVol",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
