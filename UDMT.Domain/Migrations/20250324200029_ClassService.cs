using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UDMT.Domain.Migrations
{
    /// <inheritdoc />
    public partial class ClassService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharacterClasses_CharacterClassId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_RaceAttributeBonusEnumerable_Races_RaceId",
                table: "RaceAttributeBonusEnumerable");

            migrationBuilder.DropTable(
                name: "ClassSavingThrows");

            migrationBuilder.DropTable(
                name: "CharacterClasses");

            migrationBuilder.DropIndex(
                name: "IX_Characters_CharacterClassId",
                table: "Characters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RaceAttributeBonusEnumerable",
                table: "RaceAttributeBonusEnumerable");

            migrationBuilder.DropColumn(
                name: "CharacterClassId",
                table: "Characters");

            migrationBuilder.RenameTable(
                name: "RaceAttributeBonusEnumerable",
                newName: "RaceAttributeBonuses");

            migrationBuilder.RenameColumn(
                name: "ProficencyBonus",
                table: "Characters",
                newName: "CharClassId");

            migrationBuilder.RenameIndex(
                name: "IX_RaceAttributeBonusEnumerable_RaceId",
                table: "RaceAttributeBonuses",
                newName: "IX_RaceAttributeBonuses_RaceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaceAttributeBonuses",
                table: "RaceAttributeBonuses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CharClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProficencyBonus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharClassSavingThrows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharClassId = table.Column<int>(type: "int", nullable: false),
                    AttributeType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharClassSavingThrows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharClassSavingThrows_CharClasses_CharClassId",
                        column: x => x.CharClassId,
                        principalTable: "CharClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharClassId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    IsProficient = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassSkills_CharClasses_CharClassId",
                        column: x => x.CharClassId,
                        principalTable: "CharClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CharClassId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Features_CharClasses_CharClassId",
                        column: x => x.CharClassId,
                        principalTable: "CharClasses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharClassId",
                table: "Characters",
                column: "CharClassId");

            migrationBuilder.CreateIndex(
                name: "IX_CharClassSavingThrows_CharClassId",
                table: "CharClassSavingThrows",
                column: "CharClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSkills_CharClassId_SkillId",
                table: "ClassSkills",
                columns: new[] { "CharClassId", "SkillId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassSkills_SkillId",
                table: "ClassSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_CharClassId",
                table: "Features",
                column: "CharClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CharClasses_CharClassId",
                table: "Characters",
                column: "CharClassId",
                principalTable: "CharClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RaceAttributeBonuses_Races_RaceId",
                table: "RaceAttributeBonuses",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharClasses_CharClassId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_RaceAttributeBonuses_Races_RaceId",
                table: "RaceAttributeBonuses");

            migrationBuilder.DropTable(
                name: "CharClassSavingThrows");

            migrationBuilder.DropTable(
                name: "ClassSkills");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "CharClasses");

            migrationBuilder.DropIndex(
                name: "IX_Characters_CharClassId",
                table: "Characters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RaceAttributeBonuses",
                table: "RaceAttributeBonuses");

            migrationBuilder.RenameTable(
                name: "RaceAttributeBonuses",
                newName: "RaceAttributeBonusEnumerable");

            migrationBuilder.RenameColumn(
                name: "CharClassId",
                table: "Characters",
                newName: "ProficencyBonus");

            migrationBuilder.RenameIndex(
                name: "IX_RaceAttributeBonuses_RaceId",
                table: "RaceAttributeBonusEnumerable",
                newName: "IX_RaceAttributeBonusEnumerable_RaceId");

            migrationBuilder.AddColumn<int>(
                name: "CharacterClassId",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaceAttributeBonusEnumerable",
                table: "RaceAttributeBonusEnumerable",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CharacterClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassSavingThrows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterClassId = table.Column<int>(type: "int", nullable: false),
                    AttributeType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSavingThrows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassSavingThrows_CharacterClasses_CharacterClassId",
                        column: x => x.CharacterClassId,
                        principalTable: "CharacterClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharacterClassId",
                table: "Characters",
                column: "CharacterClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSavingThrows_CharacterClassId",
                table: "ClassSavingThrows",
                column: "CharacterClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CharacterClasses_CharacterClassId",
                table: "Characters",
                column: "CharacterClassId",
                principalTable: "CharacterClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RaceAttributeBonusEnumerable_Races_RaceId",
                table: "RaceAttributeBonusEnumerable",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
