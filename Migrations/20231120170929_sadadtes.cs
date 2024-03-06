using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Automation_System.Migrations
{
    /// <inheritdoc />
    public partial class sadadtes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResponseSadadDatas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<int>(type: "int", nullable: false),
                    lang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customer_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customer_Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ref_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    currency_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseSadadDatas", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResponseSadadDatas");
        }
    }
}
