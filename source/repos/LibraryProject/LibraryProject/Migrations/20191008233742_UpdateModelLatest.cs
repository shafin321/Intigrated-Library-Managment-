using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryProject.Migrations
{
    public partial class UpdateModelLatest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patrons_LibraryBranches_LibraryBranchId",
                table: "Patrons");

            migrationBuilder.RenameColumn(
                name: "TelephoneNumber",
                table: "Patrons",
                newName: "Telephone");

            migrationBuilder.RenameColumn(
                name: "LibraryBranchId",
                table: "Patrons",
                newName: "HomeLibraryBranchId");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Patrons",
                newName: "Gender");

            migrationBuilder.RenameIndex(
                name: "IX_Patrons_LibraryBranchId",
                table: "Patrons",
                newName: "IX_Patrons_HomeLibraryBranchId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Patrons",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Patrons",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Patrons",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LibraryCardId",
                table: "Patrons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Patrons_LibraryCardId",
                table: "Patrons",
                column: "LibraryCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patrons_LibraryBranches_HomeLibraryBranchId",
                table: "Patrons",
                column: "HomeLibraryBranchId",
                principalTable: "LibraryBranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patrons_LibraryCards_LibraryCardId",
                table: "Patrons",
                column: "LibraryCardId",
                principalTable: "LibraryCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patrons_LibraryBranches_HomeLibraryBranchId",
                table: "Patrons");

            migrationBuilder.DropForeignKey(
                name: "FK_Patrons_LibraryCards_LibraryCardId",
                table: "Patrons");

            migrationBuilder.DropIndex(
                name: "IX_Patrons_LibraryCardId",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "LibraryCardId",
                table: "Patrons");

            migrationBuilder.RenameColumn(
                name: "Telephone",
                table: "Patrons",
                newName: "TelephoneNumber");

            migrationBuilder.RenameColumn(
                name: "HomeLibraryBranchId",
                table: "Patrons",
                newName: "LibraryBranchId");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Patrons",
                newName: "Email");

            migrationBuilder.RenameIndex(
                name: "IX_Patrons_HomeLibraryBranchId",
                table: "Patrons",
                newName: "IX_Patrons_LibraryBranchId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Patrons",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Patrons",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AddForeignKey(
                name: "FK_Patrons_LibraryBranches_LibraryBranchId",
                table: "Patrons",
                column: "LibraryBranchId",
                principalTable: "LibraryBranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
