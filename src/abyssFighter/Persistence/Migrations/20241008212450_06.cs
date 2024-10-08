using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("b1bbecb0-4e20-4ea6-ae5c-584fc4cb34eb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7c82e985-dcab-4052-927d-c2199e2872f2"));

            migrationBuilder.AddColumn<Guid>(
                name: "HeroClassId",
                table: "DefinitionArmorTypes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("4e514ae5-6983-4a54-96e0-9599db17b457"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 75, 233, 0, 148, 210, 174, 57, 219, 218, 33, 39, 0, 131, 125, 58, 218, 26, 67, 204, 106, 75, 99, 218, 40, 153, 217, 117, 198, 38, 168, 168, 121, 232, 201, 116, 186, 122, 39, 50, 182, 192, 250, 108, 185, 199, 195, 164, 232, 241, 158, 113, 254, 36, 174, 138, 179, 120, 61, 56, 4, 237, 115, 116, 10 }, new byte[] { 22, 171, 65, 17, 172, 26, 212, 73, 31, 49, 139, 108, 167, 80, 155, 146, 14, 195, 113, 134, 193, 168, 110, 91, 29, 246, 135, 121, 29, 0, 154, 187, 118, 217, 204, 230, 152, 65, 131, 144, 168, 125, 253, 92, 95, 44, 50, 101, 111, 20, 243, 181, 86, 9, 66, 26, 38, 221, 157, 71, 83, 216, 104, 210, 46, 223, 32, 65, 112, 64, 126, 175, 116, 245, 86, 235, 152, 149, 25, 81, 170, 40, 179, 69, 201, 205, 93, 136, 183, 216, 5, 141, 140, 193, 117, 79, 128, 218, 21, 211, 201, 63, 143, 172, 171, 13, 50, 208, 253, 40, 122, 188, 245, 203, 35, 2, 36, 85, 39, 5, 51, 109, 131, 179, 71, 219, 121, 1 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("452e7ed1-306d-49af-8814-fffc4bff4585"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("4e514ae5-6983-4a54-96e0-9599db17b457") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("452e7ed1-306d-49af-8814-fffc4bff4585"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4e514ae5-6983-4a54-96e0-9599db17b457"));

            migrationBuilder.DropColumn(
                name: "HeroClassId",
                table: "DefinitionArmorTypes");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("7c82e985-dcab-4052-927d-c2199e2872f2"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 117, 196, 48, 85, 18, 217, 156, 0, 233, 73, 137, 111, 20, 151, 197, 96, 1, 216, 101, 239, 154, 40, 81, 125, 64, 106, 116, 126, 18, 122, 77, 54, 61, 176, 11, 189, 8, 137, 137, 95, 254, 79, 154, 152, 216, 37, 123, 2, 2, 229, 126, 16, 196, 65, 223, 244, 223, 66, 7, 244, 150, 34, 31, 20 }, new byte[] { 2, 137, 137, 83, 204, 138, 81, 134, 85, 73, 10, 138, 200, 97, 66, 136, 79, 139, 123, 90, 72, 194, 200, 214, 94, 63, 197, 71, 103, 156, 173, 49, 20, 168, 221, 27, 236, 108, 241, 105, 17, 5, 200, 183, 53, 128, 17, 179, 54, 222, 78, 18, 25, 150, 35, 197, 251, 38, 192, 42, 107, 195, 25, 71, 72, 181, 240, 95, 36, 62, 141, 189, 105, 232, 79, 229, 205, 119, 47, 154, 140, 222, 128, 177, 250, 241, 77, 151, 3, 176, 94, 121, 39, 229, 210, 170, 242, 4, 199, 108, 3, 122, 171, 80, 122, 32, 25, 237, 248, 148, 223, 47, 221, 234, 104, 46, 187, 238, 196, 56, 47, 248, 138, 1, 86, 255, 63, 253 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("b1bbecb0-4e20-4ea6-ae5c-584fc4cb34eb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("7c82e985-dcab-4052-927d-c2199e2872f2") });
        }
    }
}
