using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAppRazorPages.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSpellingMistake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "Barnd",
                table: "Products",
                newName: "Brand");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ddd4b97-b474-4be0-8096-845ca93f88c8", null, "customer", "Customer" },
                    { "b4873671-273e-4492-8ac2-657561899722", null, "seller", "Seller" },
                    { "c43ace5d-3191-4642-8e60-a8a3e2b9488f", null, "admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b002c03e-eb20-4647-b30c-12c23be4ad82", 0, "", "0c136ee0-49e6-4d1a-b9a3-bc2efad93c37", new DateTime(2024, 6, 28, 20, 13, 16, 9, DateTimeKind.Local).AddTicks(2251), "admin@admin.com", false, "Junaid", "Ali", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEMuL89IlI6ZdlVyyy3ZGCtjzNK3U958OLUlPDdEjlH8wjf95Fg7TIeC9r/zl3QdaAg==", null, false, "5b8ab8ec-d7d4-4078-94f6-b5d0b8b4e3dc", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c43ace5d-3191-4642-8e60-a8a3e2b9488f", "b002c03e-eb20-4647-b30c-12c23be4ad82" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ddd4b97-b474-4be0-8096-845ca93f88c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4873671-273e-4492-8ac2-657561899722");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c43ace5d-3191-4642-8e60-a8a3e2b9488f", "b002c03e-eb20-4647-b30c-12c23be4ad82" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c43ace5d-3191-4642-8e60-a8a3e2b9488f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b002c03e-eb20-4647-b30c-12c23be4ad82");

            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "Products",
                newName: "Barnd");

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
        }
    }
}
