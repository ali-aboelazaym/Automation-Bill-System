using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Automation_System.Migrations
{
    /// <inheritdoc />
    public partial class sadad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResponseAcceToks");

            migrationBuilder.DropTable(
                name: "ResponseRefToks");

            migrationBuilder.DropTable(
                name: "AccessTokenResponses");

            migrationBuilder.DropTable(
                name: "RefreshTokenResponses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessTokenResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    errorKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessTokenResponses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokenResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    errorKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokenResponses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResponseAcceToks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessTokenResponseId = table.Column<int>(type: "int", nullable: false),
                    ExpiredAfterSeconds = table.Column<int>(type: "int", nullable: false)
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
    }
}
