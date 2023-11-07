using Microsoft.EntityFrameworkCore.Migrations;

namespace lotus.Migrations.ApplicationDb
{
    public partial class productDetailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Product_ProductId",
                table: "ProductDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDetails",
                table: "ProductDetails");

            migrationBuilder.RenameTable(
                name: "ProductDetails",
                newName: "ProductDetals");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductDetals",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProductDetals",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDetails_ProductId",
                table: "ProductDetals",
                newName: "IX_ProductDetals_productId");

            migrationBuilder.AlterColumn<string>(
                name: "productId",
                table: "ProductDetals",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDetals",
                table: "ProductDetals",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetals_Product_productId",
                table: "ProductDetals",
                column: "productId",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetals_Product_productId",
                table: "ProductDetals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDetals",
                table: "ProductDetals");

            migrationBuilder.RenameTable(
                name: "ProductDetals",
                newName: "ProductDetails");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "ProductDetails",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ProductDetails",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDetals_productId",
                table: "ProductDetails",
                newName: "IX_ProductDetails_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "ProductDetails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDetails",
                table: "ProductDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Product_ProductId",
                table: "ProductDetails",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
