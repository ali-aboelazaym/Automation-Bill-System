using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Automation_System.Migrations
{
    /// <inheritdoc />
    public partial class ZohoDataUpdating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Default_Billing_Addresses_ZohoDatas_ZohoDataId",
                table: "Customer_Default_Billing_Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer_Default_Billing_Addresses",
                table: "Customer_Default_Billing_Addresses");

            migrationBuilder.RenameTable(
                name: "Customer_Default_Billing_Addresses",
                newName: "CustomerDefaultBillingAddresses");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_Default_Billing_Addresses_ZohoDataId",
                table: "CustomerDefaultBillingAddresses",
                newName: "IX_CustomerDefaultBillingAddresses_ZohoDataId");

            migrationBuilder.AlterColumn<decimal>(
                name: "total",
                table: "ZohoDatas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerDefaultBillingAddresses",
                table: "CustomerDefaultBillingAddresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerDefaultBillingAddresses_ZohoDatas_ZohoDataId",
                table: "CustomerDefaultBillingAddresses",
                column: "ZohoDataId",
                principalTable: "ZohoDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerDefaultBillingAddresses_ZohoDatas_ZohoDataId",
                table: "CustomerDefaultBillingAddresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerDefaultBillingAddresses",
                table: "CustomerDefaultBillingAddresses");

            migrationBuilder.RenameTable(
                name: "CustomerDefaultBillingAddresses",
                newName: "Customer_Default_Billing_Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerDefaultBillingAddresses_ZohoDataId",
                table: "Customer_Default_Billing_Addresses",
                newName: "IX_Customer_Default_Billing_Addresses_ZohoDataId");

            migrationBuilder.AlterColumn<int>(
                name: "total",
                table: "ZohoDatas",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer_Default_Billing_Addresses",
                table: "Customer_Default_Billing_Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Default_Billing_Addresses_ZohoDatas_ZohoDataId",
                table: "Customer_Default_Billing_Addresses",
                column: "ZohoDataId",
                principalTable: "ZohoDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
