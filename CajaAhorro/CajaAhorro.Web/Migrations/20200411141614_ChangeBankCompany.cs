using Microsoft.EntityFrameworkCore.Migrations;

namespace CajaAhorro.Web.Migrations
{
    public partial class ChangeBankCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "BankCompanies",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "BankCompanies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankCompanies_BankId",
                table: "BankCompanies",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankCompanies_CompanyId",
                table: "BankCompanies",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankCompanies_Banks_BankId",
                table: "BankCompanies",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BankCompanies_Companies_CompanyId",
                table: "BankCompanies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankCompanies_Banks_BankId",
                table: "BankCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_BankCompanies_Companies_CompanyId",
                table: "BankCompanies");

            migrationBuilder.DropIndex(
                name: "IX_BankCompanies_BankId",
                table: "BankCompanies");

            migrationBuilder.DropIndex(
                name: "IX_BankCompanies_CompanyId",
                table: "BankCompanies");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "BankCompanies");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "BankCompanies");
        }
    }
}
