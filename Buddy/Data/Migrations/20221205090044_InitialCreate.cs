using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buddy.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "startDate",
                table: "Candidates",
                newName: "hireDate");

            migrationBuilder.RenameColumn(
                name: "endDate",
                table: "Candidates",
                newName: "DateOfBirth");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<long>(
                name: "ContactNumber",
                table: "Candidates",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IDNumber",
                table: "Candidates",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "IDNumber",
                table: "Candidates");

            migrationBuilder.RenameColumn(
                name: "hireDate",
                table: "Candidates",
                newName: "startDate");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Candidates",
                newName: "endDate");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
