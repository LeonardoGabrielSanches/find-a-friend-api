using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindAFriend.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAddressToValueObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_pet_institution_institution_id",
                table: "pet");

            migrationBuilder.DropForeignKey(
                name: "fk_photo_pet_pet_id",
                table: "photo");

            migrationBuilder.DropPrimaryKey(
                name: "pk_photo",
                table: "photo");

            migrationBuilder.DropPrimaryKey(
                name: "pk_pet",
                table: "pet");

            migrationBuilder.DropPrimaryKey(
                name: "pk_institution",
                table: "institution");

            migrationBuilder.RenameTable(
                name: "photo",
                newName: "photos");

            migrationBuilder.RenameTable(
                name: "pet",
                newName: "pets");

            migrationBuilder.RenameTable(
                name: "institution",
                newName: "institutions");

            migrationBuilder.RenameIndex(
                name: "ix_photo_pet_id",
                table: "photos",
                newName: "ix_photos_pet_id");

            migrationBuilder.RenameIndex(
                name: "ix_pet_institution_id",
                table: "pets",
                newName: "ix_pets_institution_id");

            migrationBuilder.RenameColumn(
                name: "zip_code",
                table: "institutions",
                newName: "address_zip_code");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "institutions",
                newName: "address_street");

            migrationBuilder.AddColumn<string>(
                name: "address_city",
                table: "institutions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "address_number",
                table: "institutions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "address_state",
                table: "institutions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "pk_photos",
                table: "photos",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_pets",
                table: "pets",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_institutions",
                table: "institutions",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_pets_institutions_institution_id",
                table: "pets",
                column: "institution_id",
                principalTable: "institutions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_photos_pets_pet_id",
                table: "photos",
                column: "pet_id",
                principalTable: "pets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_pets_institutions_institution_id",
                table: "pets");

            migrationBuilder.DropForeignKey(
                name: "fk_photos_pets_pet_id",
                table: "photos");

            migrationBuilder.DropPrimaryKey(
                name: "pk_photos",
                table: "photos");

            migrationBuilder.DropPrimaryKey(
                name: "pk_pets",
                table: "pets");

            migrationBuilder.DropPrimaryKey(
                name: "pk_institutions",
                table: "institutions");

            migrationBuilder.DropColumn(
                name: "address_city",
                table: "institutions");

            migrationBuilder.DropColumn(
                name: "address_number",
                table: "institutions");

            migrationBuilder.DropColumn(
                name: "address_state",
                table: "institutions");

            migrationBuilder.RenameTable(
                name: "photos",
                newName: "photo");

            migrationBuilder.RenameTable(
                name: "pets",
                newName: "pet");

            migrationBuilder.RenameTable(
                name: "institutions",
                newName: "institution");

            migrationBuilder.RenameIndex(
                name: "ix_photos_pet_id",
                table: "photo",
                newName: "ix_photo_pet_id");

            migrationBuilder.RenameIndex(
                name: "ix_pets_institution_id",
                table: "pet",
                newName: "ix_pet_institution_id");

            migrationBuilder.RenameColumn(
                name: "address_zip_code",
                table: "institution",
                newName: "zip_code");

            migrationBuilder.RenameColumn(
                name: "address_street",
                table: "institution",
                newName: "address");

            migrationBuilder.AddPrimaryKey(
                name: "pk_photo",
                table: "photo",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_pet",
                table: "pet",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_institution",
                table: "institution",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_pet_institution_institution_id",
                table: "pet",
                column: "institution_id",
                principalTable: "institution",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_photo_pet_pet_id",
                table: "photo",
                column: "pet_id",
                principalTable: "pet",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
