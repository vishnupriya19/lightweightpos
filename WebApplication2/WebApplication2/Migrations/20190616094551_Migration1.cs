using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Designation_DesignationId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Merchant_MerchantId",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Merchant",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "OrganizationName",
                table: "Merchant",
                newName: "organizationName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Merchant",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Merchant",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "MerchantId",
                table: "Merchant",
                newName: "merchantId");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Employee",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "Employee",
                newName: "salary");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Employee",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Employee",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Employee",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "MerchantId",
                table: "Employee",
                newName: "merchantId");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Employee",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "DesignationId",
                table: "Employee",
                newName: "designationId");

            migrationBuilder.RenameColumn(
                name: "Dateofjoining",
                table: "Employee",
                newName: "dateofjoining");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employee",
                newName: "employeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_MerchantId",
                table: "Employee",
                newName: "IX_Employee_merchantId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_DesignationId",
                table: "Employee",
                newName: "IX_Employee_designationId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Designation",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "DesignationId",
                table: "Designation",
                newName: "designationId");

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "Merchant",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "organizationName",
                table: "Merchant",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Merchant",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "Merchant",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "Employee",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "Employee",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "Employee",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Employee",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Employee",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dateofjoining",
                table: "Employee",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Designation",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                columns: new[] { "employeeId", "merchantId" });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    categoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    merchantId = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => new { x.categoryId, x.merchantId });
                    table.ForeignKey(
                        name: "FK_Category_Merchant",
                        column: x => x.merchantId,
                        principalTable: "Merchant",
                        principalColumn: "merchantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    merchantId = table.Column<int>(nullable: false),
                    mail = table.Column<string>(maxLength: 50, nullable: true),
                    phone = table.Column<string>(maxLength: 50, nullable: true),
                    points = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => new { x.customerId, x.merchantId });
                    table.ForeignKey(
                        name: "FK_Customer_Merchant",
                        column: x => x.merchantId,
                        principalTable: "Merchant",
                        principalColumn: "merchantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    productId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    merchantId = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    unitcost = table.Column<double>(nullable: false),
                    categoryId = table.Column<int>(nullable: true),
                    sellingprice = table.Column<double>(nullable: false),
                    comission = table.Column<double>(nullable: true),
                    rating = table.Column<int>(nullable: true),
                    createdDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    modifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    modifiedUserName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => new { x.productId, x.merchantId });
                    table.ForeignKey(
                        name: "FK_Product_Merchant",
                        column: x => x.merchantId,
                        principalTable: "Merchant",
                        principalColumn: "merchantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Category",
                        columns: x => new { x.categoryId, x.merchantId },
                        principalTable: "Category",
                        principalColumns: new[] { "categoryId", "merchantId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quantity",
                columns: table => new
                {
                    productId = table.Column<int>(nullable: false),
                    merchantId = table.Column<int>(nullable: false),
                    quantityInStock = table.Column<int>(nullable: true),
                    quantitySold = table.Column<int>(nullable: true),
                    quantityRemaining = table.Column<int>(nullable: true),
                    depletionQuantity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quantity", x => new { x.productId, x.merchantId });
                    table.UniqueConstraint("AK_Quantity_merchantId_productId", x => new { x.merchantId, x.productId });
                    table.ForeignKey(
                        name: "FK_Quantity_Product",
                        columns: x => new { x.productId, x.merchantId },
                        principalTable: "Product",
                        principalColumns: new[] { "productId", "merchantId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_merchantId",
                table: "Category",
                column: "merchantId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_merchantId",
                table: "Customer",
                column: "merchantId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_merchantId",
                table: "Product",
                column: "merchantId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_categoryId_merchantId",
                table: "Product",
                columns: new[] { "categoryId", "merchantId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Designation",
                table: "Employee",
                column: "designationId",
                principalTable: "Designation",
                principalColumn: "designationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Merchant",
                table: "Employee",
                column: "merchantId",
                principalTable: "Merchant",
                principalColumn: "merchantId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Designation",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Merchant",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Quantity");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Merchant",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "organizationName",
                table: "Merchant",
                newName: "OrganizationName");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Merchant",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Merchant",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "merchantId",
                table: "Merchant",
                newName: "MerchantId");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Employee",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "salary",
                table: "Employee",
                newName: "Salary");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Employee",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Employee",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Employee",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Employee",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "designationId",
                table: "Employee",
                newName: "DesignationId");

            migrationBuilder.RenameColumn(
                name: "dateofjoining",
                table: "Employee",
                newName: "Dateofjoining");

            migrationBuilder.RenameColumn(
                name: "merchantId",
                table: "Employee",
                newName: "MerchantId");

            migrationBuilder.RenameColumn(
                name: "employeeId",
                table: "Employee",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_merchantId",
                table: "Employee",
                newName: "IX_Employee_MerchantId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_designationId",
                table: "Employee",
                newName: "IX_Employee_DesignationId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Designation",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "designationId",
                table: "Designation",
                newName: "DesignationId");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Merchant",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrganizationName",
                table: "Merchant",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Merchant",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Merchant",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dateofjoining",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Designation",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Designation_DesignationId",
                table: "Employee",
                column: "DesignationId",
                principalTable: "Designation",
                principalColumn: "DesignationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Merchant_MerchantId",
                table: "Employee",
                column: "MerchantId",
                principalTable: "Merchant",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
