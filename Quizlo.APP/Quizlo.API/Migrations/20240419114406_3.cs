using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Quizlo.API.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "282b4f59-0832-4d5f-af19-4eacb6b7e153");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68ded0a1-148e-40c9-ab88-ba0a4bea351b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10c0e0d2-1d75-4c3d-b455-50e2d270299c", null, "Admin", "ADMIN" },
                    { "73e90cc7-d356-4826-93b1-0f8ed8528c82", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10c0e0d2-1d75-4c3d-b455-50e2d270299c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73e90cc7-d356-4826-93b1-0f8ed8528c82");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "282b4f59-0832-4d5f-af19-4eacb6b7e153", null, "User", "USER" },
                    { "68ded0a1-148e-40c9-ab88-ba0a4bea351b", null, "Admin", "ADMIN" }
                });
        }
    }
}
