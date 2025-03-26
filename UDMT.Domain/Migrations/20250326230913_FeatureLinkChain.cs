using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UDMT.Domain.Migrations
{
    /// <inheritdoc />
    public partial class FeatureLinkChain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassMechanicId",
                table: "Features",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Features",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "GrantsMagic",
                table: "Features",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHomebrew",
                table: "Features",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Features",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HitDie",
                table: "CharClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentHitPoints",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxHitPoints",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ClassMechanics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsHomebrew = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Data_MaxUses = table.Column<int>(type: "int", nullable: true),
                    Data_DurationInRounds = table.Column<int>(type: "int", nullable: true),
                    Data_ActivationType = table.Column<int>(type: "int", nullable: true),
                    Data_RestType = table.Column<int>(type: "int", nullable: true),
                    Data_Condition = table.Column<int>(type: "int", nullable: true),
                    Data_Target = table.Column<int>(type: "int", nullable: true),
                    Data_AddModifiers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data_GrantsSkillId = table.Column<int>(type: "int", nullable: true),
                    Data_RelatedAttribute = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassMechanics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassMechanics_ClassSkills_Data_GrantsSkillId",
                        column: x => x.Data_GrantsSkillId,
                        principalTable: "ClassSkills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DamageFormulas",
                columns: table => new
                {
                    MechanicDataClassMechanicId = table.Column<int>(type: "int", nullable: false),
                    DiceCount = table.Column<int>(type: "int", nullable: false),
                    DiceType = table.Column<int>(type: "int", nullable: false),
                    FlatBonus = table.Column<int>(type: "int", nullable: false),
                    ScalesWithLevel = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageFormulas", x => x.MechanicDataClassMechanicId);
                    table.ForeignKey(
                        name: "FK_DamageFormulas_ClassMechanics_MechanicDataClassMechanicId",
                        column: x => x.MechanicDataClassMechanicId,
                        principalTable: "ClassMechanics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Features_ClassMechanicId",
                table: "Features",
                column: "ClassMechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassMechanics_Data_GrantsSkillId",
                table: "ClassMechanics",
                column: "Data_GrantsSkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_ClassMechanics_ClassMechanicId",
                table: "Features",
                column: "ClassMechanicId",
                principalTable: "ClassMechanics",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_ClassMechanics_ClassMechanicId",
                table: "Features");

            migrationBuilder.DropTable(
                name: "DamageFormulas");

            migrationBuilder.DropTable(
                name: "ClassMechanics");

            migrationBuilder.DropIndex(
                name: "IX_Features_ClassMechanicId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "ClassMechanicId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "GrantsMagic",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "IsHomebrew",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "HitDie",
                table: "CharClasses");

            migrationBuilder.DropColumn(
                name: "CurrentHitPoints",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "MaxHitPoints",
                table: "Characters");
        }
    }
}
