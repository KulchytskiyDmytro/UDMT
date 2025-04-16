﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UDMT.Domain.Context;

#nullable disable

namespace UDMT.Domain.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250416120313_TotalRework")]
    partial class TotalRework
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UDMT.Domain.Entity.Back.Background", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<bool>("IsHomebrew")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Background");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Char.CharAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AttributeType")
                        .HasColumnType("int");

                    b.Property<int>("BonusModifier")
                        .HasColumnType("int");

                    b.Property<int?>("BonusOverride")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("CharAttribute");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Char.CharClassLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CharClassId")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharClassId");

                    b.HasIndex("CharacterId");

                    b.ToTable("CharClassLevel");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Char.CharCurrency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<int>("CurrencyTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("CharCurrency");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Char.CharInventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("ItemId");

                    b.ToTable("CharInventory");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Char.CharSavingThrow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AttributeType")
                        .HasColumnType("int");

                    b.Property<int>("BonusModifier")
                        .HasColumnType("int");

                    b.Property<int?>("BonusOverride")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<bool>("IsProficient")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("CharSavingThrow");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Char.CharSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BonusModifier")
                        .HasColumnType("int");

                    b.Property<int?>("BonusOverride")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("ProficiencyType")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("SkillId");

                    b.ToTable("CharSkill");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Char.CharSpell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("CharSpell");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Char.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alignment")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("BackgroundId")
                        .HasColumnType("int");

                    b.Property<string>("Backstory")
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CurrentHp")
                        .HasColumnType("int");

                    b.Property<string>("Deity")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Gender")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("MaxHp")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int?>("OverrideCurrentHp")
                        .HasColumnType("int");

                    b.Property<int?>("OverrideTemporaryHp")
                        .HasColumnType("int");

                    b.Property<string>("PlayerName")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("ProficiencyBonus")
                        .HasColumnType("int");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<int?>("TemporaryHp")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BackgroundId");

                    b.HasIndex("RaceId");

                    b.ToTable("Character");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Char.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ExchangeRateToGold")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.CharClass_Subclass.CharClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClassCastType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<bool>("GrantsSpellcasting")
                        .HasColumnType("bit");

                    b.Property<string>("HpDiceType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsHomebrew")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("SpellcastingAbility")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CharClass");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.CharClass_Subclass.CharSubclass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CastTypeOverride")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CharClassId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<bool>("GrantsSpellcasting")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHomebrew")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("CharClassId");

                    b.ToTable("CharSubclass");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.CharClass_Subclass.SpellcastingProgression", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CasterLevel")
                        .HasColumnType("int");

                    b.Property<int>("CharClassId")
                        .HasColumnType("int");

                    b.Property<int>("SlotCount")
                        .HasColumnType("int");

                    b.Property<int>("SpellLevelType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharClassId");

                    b.ToTable("SpellcastingProgression");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Feat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Feat");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Inventory.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<bool>("IsHomebrew")
                        .HasColumnType("bit");

                    b.Property<string>("ItemType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Magic.Spell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CastTimeType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CharSpellId")
                        .HasColumnType("int");

                    b.Property<string>("ComponentsType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int?>("Distance")
                        .HasColumnType("int");

                    b.Property<string>("Duration")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsRitual")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("RequiresConcentration")
                        .HasColumnType("bit");

                    b.Property<string>("SpellLevelType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpellSchoolType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpellType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharSpellId");

                    b.ToTable("Spell");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Magic.SpellClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CharClassId")
                        .HasColumnType("int");

                    b.Property<int?>("CharSubclassId")
                        .HasColumnType("int");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("SpellId")
                        .HasColumnType("int");

                    b.Property<int>("SubclassId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharClassId");

                    b.HasIndex("CharSubclassId");

                    b.HasIndex("SpellId");

                    b.ToTable("SpellClass");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Race_Subrace.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<bool>("IsHomebrew")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Race");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Race_Subrace.SubRace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<bool>("IsHomebrew")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RaceId");

                    b.ToTable("SubRace");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AttributeType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Tech.Fea.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int?>("LevelRequirement")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Feature");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Tech.Fea.FeatureRelation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.Property<int>("SourceId")
                        .HasColumnType("int");

                    b.Property<int>("SourceType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FeatureId");

                    b.ToTable("FeatureRelation");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Tech.Fea.Mechanic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DiceType")
                        .HasColumnType("int");

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FeatureId")
                        .IsUnique();

                    b.ToTable("Mechanic");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Tech.Mod.Modifier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AdvantageType")
                        .HasColumnType("int");

                    b.Property<int>("AttributeType")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("ModifierType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Modifier");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Tech.Mod.ModifierRelation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ModifierId")
                        .HasColumnType("int");

                    b.Property<int>("SourceId")
                        .HasColumnType("int");

                    b.Property<int>("SourceType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModifierId");

                    b.ToTable("ModifierRelation");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Tech.Mod.ModifierSkillRelation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ModifierId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModifierId");

                    b.HasIndex("SkillId");

                    b.ToTable("ModifierSkillRelation");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Char.CharAttribute", b =>
                {
                    b.HasOne("UDMT.Domain.Entity.Char.Character", "Character")
                        .WithMany("Attributes")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Char.CharClassLevel", b =>
                {
                    b.HasOne("UDMT.Domain.Entity.CharClass_Subclass.CharClass", "CharClass")
                        .WithMany()
                        .HasForeignKey("CharClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UDMT.Domain.Entity.Char.Character", "Character")
                        .WithMany("ClassLevels")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CharClass");

                    b.Navigation("Character");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Char.CharCurrency", b =>
                {
                    b.HasOne("UDMT.Domain.Entity.Char.Character", "Character")
                        .WithMany("Currency")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UDMT.Domain.Entity.Char.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Char.CharInventory", b =>
                {
                    b.HasOne("UDMT.Domain.Entity.Char.Character", "Character")
                        .WithMany("Inventory")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UDMT.Domain.Entity.Inventory.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Char.CharSavingThrow", b =>
                {
                    b.HasOne("UDMT.Domain.Entity.Char.Character", "Character")
                        .WithMany("SavingThrows")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Char.CharSkill", b =>
                {
                    b.HasOne("UDMT.Domain.Entity.Char.Character", "Character")
                        .WithMany("Skills")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UDMT.Domain.Entity.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Char.CharSpell", b =>
                {
                    b.HasOne("UDMT.Domain.Entity.Char.Character", "Character")
                        .WithMany("Spells")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Char.Character", b =>
                {
                    b.HasOne("UDMT.Domain.Entity.Back.Background", "Background")
                        .WithMany()
                        .HasForeignKey("BackgroundId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UDMT.Domain.Entity.Race_Subrace.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Background");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.CharClass_Subclass.CharSubclass", b =>
                {
                    b.HasOne("UDMT.Domain.Entity.CharClass_Subclass.CharClass", "CharClass")
                        .WithMany("Subclasses")
                        .HasForeignKey("CharClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CharClass");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.CharClass_Subclass.SpellcastingProgression", b =>
                {
                    b.HasOne("UDMT.Domain.Entity.CharClass_Subclass.CharClass", "CharClass")
                        .WithMany("SpellcastingProgression")
                        .HasForeignKey("CharClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CharClass");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Magic.Spell", b =>
                {
                    b.HasOne("UDMT.Domain.Entity.Char.CharSpell", "CharSpell")
                        .WithMany("Spells")
                        .HasForeignKey("CharSpellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CharSpell");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Magic.SpellClass", b =>
                {
                    b.HasOne("UDMT.Domain.Entity.CharClass_Subclass.CharClass", "CharClass")
                        .WithMany()
                        .HasForeignKey("CharClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UDMT.Domain.Entity.CharClass_Subclass.CharSubclass", "CharSubclass")
                        .WithMany()
                        .HasForeignKey("CharSubclassId");

                    b.HasOne("UDMT.Domain.Entity.Magic.Spell", "Spell")
                        .WithMany("SpellClasses")
                        .HasForeignKey("SpellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CharClass");

                    b.Navigation("CharSubclass");

                    b.Navigation("Spell");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Race_Subrace.SubRace", b =>
                {
                    b.HasOne("UDMT.Domain.Entity.Race_Subrace.Race", "Race")
                        .WithMany("SubRaces")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Race");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Tech.Fea.FeatureRelation", b =>
                {
                    b.HasOne("UDMT.Domain.Entity.Tech.Fea.Feature", "Feature")
                        .WithMany()
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feature");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Tech.Fea.Mechanic", b =>
                {
                    b.HasOne("UDMT.Domain.Entity.Tech.Fea.Feature", "Feature")
                        .WithOne("Mechanic")
                        .HasForeignKey("UDMT.Domain.Entity.Tech.Fea.Mechanic", "FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feature");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Tech.Mod.ModifierRelation", b =>
                {
                    b.HasOne("UDMT.Domain.Entity.Tech.Mod.Modifier", "Modifier")
                        .WithMany()
                        .HasForeignKey("ModifierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modifier");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Tech.Mod.ModifierSkillRelation", b =>
                {
                    b.HasOne("UDMT.Domain.Entity.Tech.Mod.Modifier", "Modifier")
                        .WithMany()
                        .HasForeignKey("ModifierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UDMT.Domain.Entity.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modifier");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Char.CharSpell", b =>
                {
                    b.Navigation("Spells");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Char.Character", b =>
                {
                    b.Navigation("Attributes");

                    b.Navigation("ClassLevels");

                    b.Navigation("Currency");

                    b.Navigation("Inventory");

                    b.Navigation("SavingThrows");

                    b.Navigation("Skills");

                    b.Navigation("Spells");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.CharClass_Subclass.CharClass", b =>
                {
                    b.Navigation("SpellcastingProgression");

                    b.Navigation("Subclasses");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Magic.Spell", b =>
                {
                    b.Navigation("SpellClasses");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Race_Subrace.Race", b =>
                {
                    b.Navigation("SubRaces");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Tech.Fea.Feature", b =>
                {
                    b.Navigation("Mechanic")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
