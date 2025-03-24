using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UDMT.Domain.Migrations
{
    /// <inheritdoc />
    public partial class SaveThrowRebuild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSavingThrow_Characters_CharacterId",
                table: "CharacterSavingThrow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterSavingThrow",
                table: "CharacterSavingThrow");

            migrationBuilder.RenameTable(
                name: "CharacterSavingThrow",
                newName: "CharacterSavingThrows");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterSavingThrow_CharacterId",
                table: "CharacterSavingThrows",
                newName: "IX_CharacterSavingThrows_CharacterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterSavingThrows",
                table: "CharacterSavingThrows",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSavingThrows_Characters_CharacterId",
                table: "CharacterSavingThrows",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSavingThrows_Characters_CharacterId",
                table: "CharacterSavingThrows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterSavingThrows",
                table: "CharacterSavingThrows");

            migrationBuilder.RenameTable(
                name: "CharacterSavingThrows",
                newName: "CharacterSavingThrow");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterSavingThrows_CharacterId",
                table: "CharacterSavingThrow",
                newName: "IX_CharacterSavingThrow_CharacterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterSavingThrow",
                table: "CharacterSavingThrow",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSavingThrow_Characters_CharacterId",
                table: "CharacterSavingThrow",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
