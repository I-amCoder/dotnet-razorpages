using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAppRazorPages.Migrations
{
    /// <inheritdoc />
    public partial class ProductsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fe175de-e197-4bac-bef4-3a08ef8c2c28");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99409724-712f-423b-a8a4-6cc6c7f64d0d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0e586427-7a2c-41d8-a308-7adb814a6df7", "d9037879-615f-4ba0-ac53-6721e381d8bd" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e586427-7a2c-41d8-a308-7adb814a6df7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9037879-615f-4ba0-ac53-6721e381d8bd");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Barnd = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(16,2)", precision: 16, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "368859bf-65d0-4f17-bb8a-5b61ac71e0cd", null, "customer", "Customer" },
                    { "4fc254eb-60e8-4d24-98c2-45b25788a035", null, "seller", "Seller" },
                    { "f65b0f60-f196-415a-b9e1-9aabab90b442", null, "admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8919c7dd-1856-463a-b35c-3d2c30a11985", 0, "", "b1e8fdd6-2d12-406d-a0de-d7b75e8a6e9b", new DateTime(2024, 6, 28, 19, 26, 55, 497, DateTimeKind.Local).AddTicks(3292), "admin@admin.com", false, "Junaid", "Ali", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEIRhOJZkd5pej3b2D1U3tmIJqKs4kVpqSz+9sCWGbCN2ZB4swKGrJnlgCu4zAurcFQ==", null, false, "e20aa459-4935-4cf1-8eb8-9feb69038ec0", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f65b0f60-f196-415a-b9e1-9aabab90b442", "8919c7dd-1856-463a-b35c-3d2c30a11985" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "368859bf-65d0-4f17-bb8a-5b61ac71e0cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fc254eb-60e8-4d24-98c2-45b25788a035");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f65b0f60-f196-415a-b9e1-9aabab90b442", "8919c7dd-1856-463a-b35c-3d2c30a11985" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f65b0f60-f196-415a-b9e1-9aabab90b442");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8919c7dd-1856-463a-b35c-3d2c30a11985");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e586427-7a2c-41d8-a308-7adb814a6df7", null, "admin", "Admin" },
                    { "2fe175de-e197-4bac-bef4-3a08ef8c2c28", null, "customer", "Customer" },
                    { "99409724-712f-423b-a8a4-6cc6c7f64d0d", null, "seller", "Seller" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d9037879-615f-4ba0-ac53-6721e381d8bd", 0, "", "5f8c0057-ead0-49e2-b99e-d8563b1e8100", new DateTime(2024, 6, 27, 21, 9, 43, 818, DateTimeKind.Local).AddTicks(715), "admin@admin.com", false, "Junaid", "Ali", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEBZONV/eHc/A0eG1+2imSJYoaV+R3ei5rg/U6ApwqWKGtpJ3KQYxH8O+SjAgHoG39Q==", null, false, "9d2c2573-81d9-4ff0-b12b-8154ebe0dd53", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0e586427-7a2c-41d8-a308-7adb814a6df7", "d9037879-615f-4ba0-ac53-6721e381d8bd" });
        }
    }
}
