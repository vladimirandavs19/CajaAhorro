using Microsoft.EntityFrameworkCore.Migrations;

namespace CajaAhorro.Web.Migrations
{
    public partial class ChangesRelationBankCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankCompanies_Banks_BankId",
                table: "BankCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_BankCompanies_Companies_CompanyId",
                table: "BankCompanies");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "BankCompanies",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BankId",
                table: "BankCompanies",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "BankCompanies",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BankId",
                table: "BankCompanies",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BankCompanies_Banks_BankId",
                table: "BankCompanies",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BankCompanies_Companies_CompanyId",
                table: "BankCompanies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
