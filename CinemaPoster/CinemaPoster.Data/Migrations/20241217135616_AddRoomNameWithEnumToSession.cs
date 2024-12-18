using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaPoster.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomNameWithEnumToSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RoomName",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Blue",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RoomName",
                table: "Sessions",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Blue");
        }
    }
}
