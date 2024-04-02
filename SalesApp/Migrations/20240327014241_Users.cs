using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesApp.Migrations
{
    /// <inheritdoc />
    public partial class Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "SolutionEngineers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SolutionEngineers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "AccountExecutives");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AccountExecutives");

            migrationBuilder.AlterColumn<string>(
                name: "Properties",
                table: "SowProducts",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "SolutionEngineers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "Properties",
                table: "AccountProducts",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "AccountExecutives",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    UserType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolutionEngineers_UserId",
                table: "SolutionEngineers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountExecutives_UserId",
                table: "AccountExecutives",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountExecutives_Users_UserId",
                table: "AccountExecutives",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionEngineers_Users_UserId",
                table: "SolutionEngineers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountExecutives_Users_UserId",
                table: "AccountExecutives");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionEngineers_Users_UserId",
                table: "SolutionEngineers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_SolutionEngineers_UserId",
                table: "SolutionEngineers");

            migrationBuilder.DropIndex(
                name: "IX_AccountExecutives_UserId",
                table: "AccountExecutives");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SolutionEngineers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AccountExecutives");

            migrationBuilder.AlterColumn<string>(
                name: "Properties",
                table: "SowProducts",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "SolutionEngineers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SolutionEngineers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Properties",
                table: "AccountProducts",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AccountExecutives",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AccountExecutives",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
