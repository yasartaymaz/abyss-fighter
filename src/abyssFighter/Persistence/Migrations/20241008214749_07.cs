using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("452e7ed1-306d-49af-8814-fffc4bff4585"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4e514ae5-6983-4a54-96e0-9599db17b457"));

            migrationBuilder.AddColumn<decimal>(
                name: "DefencePoints",
                table: "DefinitionWeapons",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 126, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "DefinitionArmorTypes.Admin", null },
                    { 127, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "DefinitionArmorTypes.Read", null },
                    { 128, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "DefinitionArmorTypes.Write", null },
                    { 129, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "DefinitionArmorTypes.Create", null },
                    { 130, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "DefinitionArmorTypes.Update", null },
                    { 131, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "DefinitionArmorTypes.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("ceec300c-0d00-4c55-ae46-31511b3a9f3b"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 236, 115, 119, 188, 255, 145, 246, 179, 207, 107, 237, 164, 152, 188, 164, 204, 101, 215, 153, 239, 118, 144, 147, 14, 29, 157, 205, 206, 75, 142, 99, 109, 228, 87, 31, 61, 0, 146, 237, 136, 61, 217, 95, 175, 157, 148, 184, 246, 251, 37, 135, 2, 182, 225, 135, 88, 23, 12, 176, 32, 201, 67, 238, 149 }, new byte[] { 224, 135, 149, 43, 117, 0, 54, 43, 217, 81, 203, 191, 33, 223, 143, 64, 57, 83, 59, 231, 69, 43, 211, 61, 19, 35, 108, 129, 55, 135, 134, 167, 89, 219, 12, 177, 97, 101, 215, 66, 150, 193, 29, 115, 43, 105, 160, 116, 13, 120, 117, 242, 238, 217, 149, 119, 74, 97, 68, 103, 155, 4, 47, 177, 3, 103, 172, 151, 188, 139, 85, 232, 72, 143, 63, 93, 56, 18, 142, 77, 129, 215, 118, 152, 126, 156, 13, 145, 241, 188, 153, 178, 236, 7, 142, 128, 14, 105, 120, 58, 208, 246, 191, 21, 17, 101, 166, 38, 130, 216, 19, 196, 130, 41, 157, 74, 244, 255, 57, 47, 14, 162, 103, 54, 244, 128, 119, 36 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("055cea21-ff58-4210-9a8e-fcae6817ff72"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("ceec300c-0d00-4c55-ae46-31511b3a9f3b") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("055cea21-ff58-4210-9a8e-fcae6817ff72"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ceec300c-0d00-4c55-ae46-31511b3a9f3b"));

            migrationBuilder.DropColumn(
                name: "DefencePoints",
                table: "DefinitionWeapons");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("4e514ae5-6983-4a54-96e0-9599db17b457"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 75, 233, 0, 148, 210, 174, 57, 219, 218, 33, 39, 0, 131, 125, 58, 218, 26, 67, 204, 106, 75, 99, 218, 40, 153, 217, 117, 198, 38, 168, 168, 121, 232, 201, 116, 186, 122, 39, 50, 182, 192, 250, 108, 185, 199, 195, 164, 232, 241, 158, 113, 254, 36, 174, 138, 179, 120, 61, 56, 4, 237, 115, 116, 10 }, new byte[] { 22, 171, 65, 17, 172, 26, 212, 73, 31, 49, 139, 108, 167, 80, 155, 146, 14, 195, 113, 134, 193, 168, 110, 91, 29, 246, 135, 121, 29, 0, 154, 187, 118, 217, 204, 230, 152, 65, 131, 144, 168, 125, 253, 92, 95, 44, 50, 101, 111, 20, 243, 181, 86, 9, 66, 26, 38, 221, 157, 71, 83, 216, 104, 210, 46, 223, 32, 65, 112, 64, 126, 175, 116, 245, 86, 235, 152, 149, 25, 81, 170, 40, 179, 69, 201, 205, 93, 136, 183, 216, 5, 141, 140, 193, 117, 79, 128, 218, 21, 211, 201, 63, 143, 172, 171, 13, 50, 208, 253, 40, 122, 188, 245, 203, 35, 2, 36, 85, 39, 5, 51, 109, 131, 179, 71, 219, 121, 1 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("452e7ed1-306d-49af-8814-fffc4bff4585"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("4e514ae5-6983-4a54-96e0-9599db17b457") });
        }
    }
}
