using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Automation_System.Migrations
{
    /// <inheritdoc />
    public partial class sadadServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "RefreshTokenResponses");

            migrationBuilder.DropColumn(
                name: "AccessToken",
                table: "AccessTokenResponses");

            migrationBuilder.CreateTable(
                name: "ResponseAcceToks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiredAfterSeconds = table.Column<int>(type: "int", nullable: false),
                    AccessTokenResponseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseAcceToks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponseAcceToks_AccessTokenResponses_AccessTokenResponseId",
                        column: x => x.AccessTokenResponseId,
                        principalTable: "AccessTokenResponses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResponseRefToks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshTokenResponseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseRefToks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponseRefToks_RefreshTokenResponses_RefreshTokenResponseId",
                        column: x => x.RefreshTokenResponseId,
                        principalTable: "RefreshTokenResponses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResponseAcceToks_AccessTokenResponseId",
                table: "ResponseAcceToks",
                column: "AccessTokenResponseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResponseRefToks_RefreshTokenResponseId",
                table: "ResponseRefToks",
                column: "RefreshTokenResponseId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResponseAcceToks");

            migrationBuilder.DropTable(
                name: "ResponseRefToks");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "RefreshTokenResponses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccessToken",
                table: "AccessTokenResponses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
