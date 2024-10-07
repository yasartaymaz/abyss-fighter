using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d2f868cf-cdb3-4445-9b01-c6bea315a42e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("240a449d-b870-455d-9b96-1fbb0c927bca"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("0cace690-b6be-49ae-8132-328cdba652e8"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 151, 150, 104, 91, 37, 170, 51, 62, 96, 14, 129, 201, 168, 20, 178, 164, 52, 116, 250, 173, 143, 132, 40, 97, 13, 130, 169, 107, 234, 52, 156, 67, 37, 232, 120, 48, 254, 95, 9, 11, 206, 52, 152, 180, 12, 149, 252, 175, 62, 85, 155, 68, 123, 101, 228, 93, 173, 88, 231, 66, 215, 28, 24, 6 }, new byte[] { 6, 250, 66, 175, 221, 162, 95, 78, 112, 85, 179, 2, 124, 113, 138, 88, 79, 133, 228, 211, 35, 98, 191, 2, 39, 181, 90, 65, 110, 83, 180, 67, 238, 67, 33, 200, 181, 56, 153, 67, 168, 183, 47, 55, 48, 93, 192, 69, 208, 6, 59, 136, 117, 174, 232, 231, 168, 236, 207, 173, 167, 206, 127, 174, 88, 15, 25, 84, 200, 216, 92, 181, 149, 111, 151, 150, 36, 64, 47, 8, 93, 135, 162, 75, 145, 215, 140, 202, 11, 126, 10, 103, 173, 25, 204, 21, 195, 92, 72, 210, 51, 0, 142, 169, 75, 238, 254, 31, 117, 201, 252, 65, 147, 145, 16, 175, 51, 242, 239, 107, 92, 36, 31, 32, 99, 10, 62, 157 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d206a30c-20bd-4466-8d11-b8fad54b9951"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("0cace690-b6be-49ae-8132-328cdba652e8") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("240a449d-b870-455d-9b96-1fbb0c927bca"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 197, 165, 10, 78, 211, 141, 199, 131, 58, 93, 111, 49, 103, 229, 252, 27, 1, 171, 177, 110, 235, 127, 59, 132, 110, 31, 27, 252, 83, 20, 238, 83, 185, 248, 99, 123, 38, 65, 150, 36, 235, 156, 0, 212, 193, 145, 90, 178, 117, 58, 127, 145, 24, 220, 115, 160, 41, 217, 198, 138, 199, 146, 98, 11 }, new byte[] { 204, 154, 26, 233, 85, 141, 164, 168, 6, 5, 151, 25, 157, 21, 153, 140, 79, 56, 0, 82, 223, 82, 82, 0, 10, 179, 209, 120, 173, 141, 3, 124, 53, 63, 97, 80, 40, 103, 98, 59, 184, 246, 40, 80, 91, 243, 21, 196, 1, 246, 114, 201, 109, 69, 33, 150, 68, 57, 59, 199, 195, 57, 219, 198, 36, 19, 96, 217, 12, 151, 119, 166, 111, 1, 175, 190, 163, 37, 13, 0, 18, 171, 46, 58, 79, 42, 70, 48, 155, 220, 137, 140, 183, 97, 201, 123, 230, 73, 67, 160, 145, 14, 106, 104, 199, 70, 167, 180, 59, 87, 31, 116, 187, 93, 200, 82, 146, 43, 223, 44, 101, 116, 119, 242, 85, 247, 207, 28 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d2f868cf-cdb3-4445-9b01-c6bea315a42e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("240a449d-b870-455d-9b96-1fbb0c927bca") });
        }
    }
}
