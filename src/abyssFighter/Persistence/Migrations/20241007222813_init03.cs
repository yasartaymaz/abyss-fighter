using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d206a30c-20bd-4466-8d11-b8fad54b9951"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0cace690-b6be-49ae-8132-328cdba652e8"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("e0268329-3092-4866-bee3-b154da9a1d0c"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 252, 225, 220, 207, 90, 38, 15, 174, 72, 7, 154, 120, 185, 233, 251, 26, 86, 254, 179, 67, 57, 206, 161, 237, 82, 16, 122, 160, 95, 220, 114, 47, 221, 164, 66, 23, 32, 201, 180, 68, 199, 194, 152, 28, 229, 124, 153, 40, 242, 215, 74, 215, 236, 138, 54, 118, 99, 161, 125, 167, 62, 109, 198, 40 }, new byte[] { 30, 75, 118, 43, 7, 162, 210, 42, 43, 251, 20, 201, 201, 204, 11, 29, 84, 61, 206, 206, 51, 197, 11, 87, 18, 226, 148, 85, 3, 34, 199, 30, 50, 96, 51, 61, 250, 118, 4, 71, 248, 125, 155, 240, 91, 56, 241, 108, 245, 6, 99, 119, 163, 169, 66, 241, 122, 200, 197, 196, 191, 242, 79, 216, 19, 213, 121, 132, 49, 87, 43, 179, 14, 170, 49, 96, 70, 149, 4, 38, 52, 111, 60, 226, 241, 229, 24, 104, 21, 126, 33, 113, 41, 78, 106, 112, 34, 188, 91, 222, 77, 107, 218, 236, 165, 11, 124, 33, 222, 213, 247, 164, 169, 23, 76, 51, 89, 81, 212, 188, 133, 154, 8, 97, 239, 139, 231, 206 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("a58a74da-ce59-4a43-b56b-757d76ab0443"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("e0268329-3092-4866-bee3-b154da9a1d0c") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a58a74da-ce59-4a43-b56b-757d76ab0443"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e0268329-3092-4866-bee3-b154da9a1d0c"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("0cace690-b6be-49ae-8132-328cdba652e8"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 151, 150, 104, 91, 37, 170, 51, 62, 96, 14, 129, 201, 168, 20, 178, 164, 52, 116, 250, 173, 143, 132, 40, 97, 13, 130, 169, 107, 234, 52, 156, 67, 37, 232, 120, 48, 254, 95, 9, 11, 206, 52, 152, 180, 12, 149, 252, 175, 62, 85, 155, 68, 123, 101, 228, 93, 173, 88, 231, 66, 215, 28, 24, 6 }, new byte[] { 6, 250, 66, 175, 221, 162, 95, 78, 112, 85, 179, 2, 124, 113, 138, 88, 79, 133, 228, 211, 35, 98, 191, 2, 39, 181, 90, 65, 110, 83, 180, 67, 238, 67, 33, 200, 181, 56, 153, 67, 168, 183, 47, 55, 48, 93, 192, 69, 208, 6, 59, 136, 117, 174, 232, 231, 168, 236, 207, 173, 167, 206, 127, 174, 88, 15, 25, 84, 200, 216, 92, 181, 149, 111, 151, 150, 36, 64, 47, 8, 93, 135, 162, 75, 145, 215, 140, 202, 11, 126, 10, 103, 173, 25, 204, 21, 195, 92, 72, 210, 51, 0, 142, 169, 75, 238, 254, 31, 117, 201, 252, 65, 147, 145, 16, 175, 51, 242, 239, 107, 92, 36, 31, 32, 99, 10, 62, 157 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d206a30c-20bd-4466-8d11-b8fad54b9951"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("0cace690-b6be-49ae-8132-328cdba652e8") });
        }
    }
}
