using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindAFriend.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateNewColumnPetType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "pet_type",
                table: "pets",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pet_type",
                table: "pets");
        }
    }
}
