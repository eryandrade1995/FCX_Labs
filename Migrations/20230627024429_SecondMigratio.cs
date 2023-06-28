using Microsoft.EntityFrameworkCore.Migrations;

namespace FCX_Labs.Migrations
{
    public partial class SecondMigratio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "longin",
                table: "Users",
                newName: "login");

            migrationBuilder.AlterColumn<int>(
                name: "profile",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<long>(
                name: "Userid",
                table: "Person",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_Userid",
                table: "Person",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Users_Userid",
                table: "Person",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Users_Userid",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_Userid",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "login",
                table: "Users",
                newName: "longin");

            migrationBuilder.AlterColumn<int>(
                name: "profile",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
