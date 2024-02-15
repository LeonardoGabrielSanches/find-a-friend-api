using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindAFriend.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "institution",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    responsible_name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    zip_code = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_institution", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pet",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    about = table.Column<string>(type: "text", nullable: false),
                    age = table.Column<int>(type: "integer", nullable: false),
                    size = table.Column<int>(type: "integer", nullable: false),
                    energy_level = table.Column<int>(type: "integer", nullable: false),
                    dependency_level = table.Column<int>(type: "integer", nullable: false),
                    environment_size = table.Column<int>(type: "integer", nullable: false),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    institution_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pet", x => x.id);
                    table.ForeignKey(
                        name: "fk_pet_institution_institution_id",
                        column: x => x.institution_id,
                        principalTable: "institution",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "photo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false),
                    pet_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_photo", x => x.id);
                    table.ForeignKey(
                        name: "fk_photo_pet_pet_id",
                        column: x => x.pet_id,
                        principalTable: "pet",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_pet_institution_id",
                table: "pet",
                column: "institution_id");

            migrationBuilder.CreateIndex(
                name: "ix_photo_pet_id",
                table: "photo",
                column: "pet_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "photo");

            migrationBuilder.DropTable(
                name: "pet");

            migrationBuilder.DropTable(
                name: "institution");
        }
    }
}
