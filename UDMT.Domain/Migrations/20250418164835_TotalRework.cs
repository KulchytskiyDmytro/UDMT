using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UDMT.Domain.Migrations
{
    /// <inheritdoc />
    public partial class TotalRework : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterAttributes");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "PlayerClasses");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.CreateTable(
                name: "Background",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IsHomebrew = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Background", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    GrantsSpellcasting = table.Column<bool>(type: "bit", nullable: false),
                    IsHomebrew = table.Column<bool>(type: "bit", nullable: false),
                    SpellcastingAbility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HpDiceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassCastType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExchangeRateToGold = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    LevelRequirement = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsHomebrew = table.Column<bool>(type: "bit", nullable: false),
                    ItemType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modifier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ModifierType = table.Column<int>(type: "int", nullable: true),
                    AttributeType = table.Column<int>(type: "int", nullable: true),
                    ProficiencyType = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: true),
                    AdvantageType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modifier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Race",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IsHomebrew = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttributeType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharSubclass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    GrantsSpellcasting = table.Column<bool>(type: "bit", nullable: false),
                    IsHomebrew = table.Column<bool>(type: "bit", nullable: false),
                    CharClassId = table.Column<int>(type: "int", nullable: false),
                    CastTypeOverride = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharSubclass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharSubclass_CharClass_CharClassId",
                        column: x => x.CharClassId,
                        principalTable: "CharClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpellcastingProgression",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharClassId = table.Column<int>(type: "int", nullable: false),
                    CasterLevel = table.Column<int>(type: "int", nullable: false),
                    SlotCount = table.Column<int>(type: "int", nullable: false),
                    SpellLevelType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellcastingProgression", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellcastingProgression_CharClass_CharClassId",
                        column: x => x.CharClassId,
                        principalTable: "CharClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeatureRelation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceId = table.Column<int>(type: "int", nullable: false),
                    SourceType = table.Column<int>(type: "int", nullable: false),
                    FeatureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeatureRelation_Feature_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mechanic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiceType = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mechanic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mechanic_Feature_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModifierRelation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceId = table.Column<int>(type: "int", nullable: false),
                    SourceType = table.Column<int>(type: "int", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModifierRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModifierRelation_Modifier_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "Modifier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Alignment = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Deity = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Backstory = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    ProficiencyBonus = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: true),
                    ArmorClass = table.Column<int>(type: "int", nullable: true),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    BackgroundId = table.Column<int>(type: "int", nullable: false),
                    MaxHp = table.Column<int>(type: "int", nullable: false),
                    CurrentHp = table.Column<int>(type: "int", nullable: false),
                    TemporaryHp = table.Column<int>(type: "int", nullable: true),
                    OverrideCurrentHp = table.Column<int>(type: "int", nullable: true),
                    OverrideTemporaryHp = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_Background_BackgroundId",
                        column: x => x.BackgroundId,
                        principalTable: "Background",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Character_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubRace",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IsHomebrew = table.Column<bool>(type: "bit", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubRace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubRace_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModifierSkillRelation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModifierSkillRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModifierSkillRelation_Modifier_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "Modifier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModifierSkillRelation_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharAttribute",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeType = table.Column<int>(type: "int", nullable: false),
                    BonusModifier = table.Column<int>(type: "int", nullable: false),
                    BonusOverride = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: false),
                    ValueOverride = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharAttribute_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharClassLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    CharClassId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharClassLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharClassLevel_CharClass_CharClassId",
                        column: x => x.CharClassId,
                        principalTable: "CharClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharClassLevel_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharCurrency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyTypeId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharCurrency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharCurrency_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharCurrency_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharInventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharInventory_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharInventory_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharSavingThrow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeType = table.Column<int>(type: "int", nullable: false),
                    BonusModifier = table.Column<int>(type: "int", nullable: false),
                    BonusOverride = table.Column<int>(type: "int", nullable: true),
                    IsProficient = table.Column<bool>(type: "bit", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharSavingThrow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharSavingThrow_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    ProficiencyType = table.Column<int>(type: "int", nullable: false),
                    BonusModifier = table.Column<int>(type: "int", nullable: false),
                    BonusOverride = table.Column<int>(type: "int", nullable: true),
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharSkill_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharSpell",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharSpell", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharSpell_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spell",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharSpellId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    SpellType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpellSchoolType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CastTimeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: true),
                    ComponentsType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SpellLevelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRitual = table.Column<bool>(type: "bit", nullable: false),
                    RequiresConcentration = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spell", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spell_CharSpell_CharSpellId",
                        column: x => x.CharSpellId,
                        principalTable: "CharSpell",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpellClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpellId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    CharClassId = table.Column<int>(type: "int", nullable: false),
                    SubclassId = table.Column<int>(type: "int", nullable: false),
                    CharSubclassId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellClass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellClass_CharClass_CharClassId",
                        column: x => x.CharClassId,
                        principalTable: "CharClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpellClass_CharSubclass_CharSubclassId",
                        column: x => x.CharSubclassId,
                        principalTable: "CharSubclass",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpellClass_Spell_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spell",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_BackgroundId",
                table: "Character",
                column: "BackgroundId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_RaceId",
                table: "Character",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_CharAttribute_CharacterId",
                table: "CharAttribute",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharClassLevel_CharacterId",
                table: "CharClassLevel",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharClassLevel_CharClassId",
                table: "CharClassLevel",
                column: "CharClassId");

            migrationBuilder.CreateIndex(
                name: "IX_CharCurrency_CharacterId",
                table: "CharCurrency",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharCurrency_CurrencyId",
                table: "CharCurrency",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_CharacterId",
                table: "CharInventory",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_ItemId",
                table: "CharInventory",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CharSavingThrow_CharacterId",
                table: "CharSavingThrow",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharSkill_CharacterId",
                table: "CharSkill",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharSkill_SkillId",
                table: "CharSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_CharSpell_CharacterId",
                table: "CharSpell",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharSubclass_CharClassId",
                table: "CharSubclass",
                column: "CharClassId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureRelation_FeatureId",
                table: "FeatureRelation",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Mechanic_FeatureId",
                table: "Mechanic",
                column: "FeatureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModifierRelation_ModifierId",
                table: "ModifierRelation",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_ModifierSkillRelation_ModifierId",
                table: "ModifierSkillRelation",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_ModifierSkillRelation_SkillId",
                table: "ModifierSkillRelation",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Spell_CharSpellId",
                table: "Spell",
                column: "CharSpellId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellcastingProgression_CharClassId",
                table: "SpellcastingProgression",
                column: "CharClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellClass_CharClassId",
                table: "SpellClass",
                column: "CharClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellClass_CharSubclassId",
                table: "SpellClass",
                column: "CharSubclassId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellClass_SpellId",
                table: "SpellClass",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_SubRace_RaceId",
                table: "SubRace",
                column: "RaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharAttribute");

            migrationBuilder.DropTable(
                name: "CharClassLevel");

            migrationBuilder.DropTable(
                name: "CharCurrency");

            migrationBuilder.DropTable(
                name: "CharInventory");

            migrationBuilder.DropTable(
                name: "CharSavingThrow");

            migrationBuilder.DropTable(
                name: "CharSkill");

            migrationBuilder.DropTable(
                name: "Feat");

            migrationBuilder.DropTable(
                name: "FeatureRelation");

            migrationBuilder.DropTable(
                name: "Mechanic");

            migrationBuilder.DropTable(
                name: "ModifierRelation");

            migrationBuilder.DropTable(
                name: "ModifierSkillRelation");

            migrationBuilder.DropTable(
                name: "SpellcastingProgression");

            migrationBuilder.DropTable(
                name: "SpellClass");

            migrationBuilder.DropTable(
                name: "SubRace");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Feature");

            migrationBuilder.DropTable(
                name: "Modifier");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "CharSubclass");

            migrationBuilder.DropTable(
                name: "Spell");

            migrationBuilder.DropTable(
                name: "CharClass");

            migrationBuilder.DropTable(
                name: "CharSpell");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Background");

            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.CreateTable(
                name: "PlayerClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerClassName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Atribute = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Race_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerClassId = table.Column<int>(type: "int", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_PlayerClasses_PlayerClassId",
                        column: x => x.PlayerClassId,
                        principalTable: "PlayerClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    AttributeType = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterAttributes_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAttributes_PlayerId",
                table: "CharacterAttributes",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerClassId",
                table: "Players",
                column: "PlayerClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_RaceId",
                table: "Players",
                column: "RaceId");
        }
    }
}
