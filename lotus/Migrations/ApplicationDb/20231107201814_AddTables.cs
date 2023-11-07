using Microsoft.EntityFrameworkCore.Migrations;

namespace lotus.Migrations.ApplicationDb
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_ApplicationUser_UserId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Product_ProductId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ApplicationUser_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetals_Product_productId",
                table: "ProductDetals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDetals",
                table: "ProductDetals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "ProductDetals",
                newName: "ProductDetails");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Cart",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cart",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_ProductId",
                table: "Cart",
                newName: "IX_Cart_productId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDetals_productId",
                table: "ProductDetails",
                newName: "IX_ProductDetails_productId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Order",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Order",
                newName: "totalPrice");

            migrationBuilder.RenameColumn(
                name: "Products",
                table: "Order",
                newName: "products");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Order",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IsPayed",
                table: "Order",
                newName: "isPaid");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Order",
                newName: "IX_Order_userId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Cart",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "productId",
                table: "Cart",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Order",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDetails",
                table: "ProductDetails",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_ApplicationUser_UserId",
                table: "Cart",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Product_productId",
                table: "Cart",
                column: "productId",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_ApplicationUser_userId",
                table: "Order",
                column: "userId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Product_productId",
                table: "ProductDetails",
                column: "productId",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_ApplicationUser_UserId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Product_productId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_ApplicationUser_userId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Product_productId",
                table: "ProductDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDetails",
                table: "ProductDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "ProductDetails",
                newName: "ProductDetals");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Cart",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Cart",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_productId",
                table: "Cart",
                newName: "IX_Cart_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDetails_productId",
                table: "ProductDetals",
                newName: "IX_ProductDetals_productId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "totalPrice",
                table: "Orders",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "products",
                table: "Orders",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "isPaid",
                table: "Orders",
                newName: "IsPayed");

            migrationBuilder.RenameIndex(
                name: "IX_Order_userId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "Cart",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Cart",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDetals",
                table: "ProductDetals",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_ApplicationUser_UserId",
                table: "Cart",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Product_ProductId",
                table: "Cart",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ApplicationUser_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetals_Product_productId",
                table: "ProductDetals",
                column: "productId",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
