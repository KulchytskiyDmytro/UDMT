using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UDMT.Domain.Migrations
{
    /// <inheritdoc />
    public partial class RaceSubRace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Atribute",
                table: "Races");

            migrationBuilder.RenameColumn(
                name: "Race_Name",
                table: "Races",
                newName: "Name");

            migrationBuilder.AddColumn<bool>(
                name: "IsHomebrew",
                table: "Races",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRequireSubrace",
                table: "Races",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PlayerClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "RaceAttributeBonusEnumerable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeType = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceAttributeBonusEnumerable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceAttributeBonusEnumerable_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceRelations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    SubraceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceRelations_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceRelations_Races_SubraceId",
                        column: x => x.SubraceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaceAttributeBonusEnumerable_RaceId",
                table: "RaceAttributeBonusEnumerable",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceRelations_RaceId_SubraceId",
                table: "RaceRelations",
                columns: new[] { "RaceId", "SubraceId" },
                unique: true,
                filter: "[SubraceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RaceRelations_SubraceId",
                table: "RaceRelations",
                column: "SubraceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaceAttributeBonusEnumerable");

            migrationBuilder.DropTable(
                name: "RaceRelations");

            migrationBuilder.DropColumn(
                name: "IsHomebrew",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "IsRequireSubrace",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PlayerClasses");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Races",
                newName: "Race_Name");

            migrationBuilder.AddColumn<int>(
                name: "Atribute",
                table: "Races",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
