using Microsoft.EntityFrameworkCore.Migrations;

namespace CajaAhorro.Web.Migrations
{
    public partial class ChangesParameterModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Parameters");

            migrationBuilder.AlterColumn<string>(
                name: "TypeName",
                table: "Parameters",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "StringValue",
                table: "Parameters",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "ParameterType",
                table: "Parameters",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParameterType",
                table: "Parameters");

            migrationBuilder.AlterColumn<string>(
                name: "TypeName",
                table: "Parameters",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "StringValue",
                table: "Parameters",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Parameters",
                nullable: false,
                defaultValue: "");
        }
    }
}
