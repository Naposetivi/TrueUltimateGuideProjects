using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class TaxIdentificationNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TaxIdentificationNumber",
                table: "Persons",
                type: "varchar(8)",
                nullable: true,
                defaultValue: "ABC12345");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CountryID",
                table: "Persons",
                column: "CountryID");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_TIN",
                table: "Persons",
                sql: "len([TaxIdentificationNumber]) = 8");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Countries_CountryID",
                table: "Persons",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "CountryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Countries_CountryID",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_CountryID",
                table: "Persons");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_TIN",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "TaxIdentificationNumber",
                table: "Persons");
        }
    }
}
