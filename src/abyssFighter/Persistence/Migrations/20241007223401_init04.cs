using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("a21bc598-7f22-4e40-9f9e-2ee7ddfab2bc"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 71, 33, 137, 137, 82, 65, 115, 167, 28, 136, 89, 68, 147, 18, 218, 23, 37, 90, 237, 72, 93, 87, 31, 117, 253, 43, 1, 50, 8, 126, 106, 48, 155, 98, 26, 124, 162, 123, 165, 106, 49, 17, 21, 136, 41, 147, 1, 11, 165, 98, 254, 145, 102, 101, 42, 224, 177, 43, 105, 75, 19, 238, 59, 177 }, new byte[] { 216, 205, 223, 166, 248, 50, 155, 68, 197, 45, 90, 6, 45, 169, 179, 163, 50, 29, 78, 94, 113, 105, 215, 59, 101, 122, 156, 131, 169, 255, 163, 130, 102, 164, 72, 20, 57, 154, 92, 229, 224, 251, 4, 76, 215, 172, 41, 211, 48, 5, 143, 121, 244, 70, 144, 37, 250, 84, 156, 175, 120, 77, 193, 248, 93, 240, 151, 68, 208, 109, 44, 81, 90, 189, 205, 124, 88, 164, 57, 179, 23, 171, 159, 160, 216, 66, 25, 236, 78, 189, 157, 27, 122, 23, 19, 176, 211, 182, 89, 217, 183, 69, 163, 38, 119, 100, 253, 12, 222, 227, 59, 227, 220, 62, 43, 76, 245, 255, 222, 201, 86, 3, 109, 64, 45, 218, 232, 187 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("4e5a57c4-f491-46ef-abbc-0717ad9022f8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("a21bc598-7f22-4e40-9f9e-2ee7ddfab2bc") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("4e5a57c4-f491-46ef-abbc-0717ad9022f8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a21bc598-7f22-4e40-9f9e-2ee7ddfab2bc"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("e0268329-3092-4866-bee3-b154da9a1d0c"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 252, 225, 220, 207, 90, 38, 15, 174, 72, 7, 154, 120, 185, 233, 251, 26, 86, 254, 179, 67, 57, 206, 161, 237, 82, 16, 122, 160, 95, 220, 114, 47, 221, 164, 66, 23, 32, 201, 180, 68, 199, 194, 152, 28, 229, 124, 153, 40, 242, 215, 74, 215, 236, 138, 54, 118, 99, 161, 125, 167, 62, 109, 198, 40 }, new byte[] { 30, 75, 118, 43, 7, 162, 210, 42, 43, 251, 20, 201, 201, 204, 11, 29, 84, 61, 206, 206, 51, 197, 11, 87, 18, 226, 148, 85, 3, 34, 199, 30, 50, 96, 51, 61, 250, 118, 4, 71, 248, 125, 155, 240, 91, 56, 241, 108, 245, 6, 99, 119, 163, 169, 66, 241, 122, 200, 197, 196, 191, 242, 79, 216, 19, 213, 121, 132, 49, 87, 43, 179, 14, 170, 49, 96, 70, 149, 4, 38, 52, 111, 60, 226, 241, 229, 24, 104, 21, 126, 33, 113, 41, 78, 106, 112, 34, 188, 91, 222, 77, 107, 218, 236, 165, 11, 124, 33, 222, 213, 247, 164, 169, 23, 76, 51, 89, 81, 212, 188, 133, 154, 8, 97, 239, 139, 231, 206 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("a58a74da-ce59-4a43-b56b-757d76ab0443"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("e0268329-3092-4866-bee3-b154da9a1d0c") });
        }
    }
}
