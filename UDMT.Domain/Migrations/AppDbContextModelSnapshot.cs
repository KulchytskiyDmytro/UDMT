﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UDMT.Domain.Context;

#nullable disable

namespace UDMT.Domain.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UDMT.Domain.Entity.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CharacterClassId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProficencyBonus")
                        .HasColumnType("int");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterClassId");

                    b.HasIndex("RaceId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.CharacterAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AttributeType")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("CharacterAttributes");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.CharacterClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CharacterClasses");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.CharacterSavingThrow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AttributeType")
                        .HasColumnType("int");

                    b.Property<int>("BonusOverride")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<bool>("IsProficient")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("CharacterSavingThrow");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.CharacterSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BonusOverride")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsProficient")
                        .HasColumnType("bit");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("SkillId");

                    b.ToTable("CharacterSkills");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.ClassSavingThrow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AttributeType")
                        .HasColumnType("int");

                    b.Property<int>("CharacterClassId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterClassId");

                    b.ToTable("ClassSavingThrows");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsHomebrew")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRequireSubrace")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.RaceAttributeBonus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AttributeType")
                        .HasColumnType("int");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RaceId");

                    b.ToTable("RaceAttributeBonusEnumerable");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.RaceRelation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<int?>("SubraceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubraceId");

                    b.HasIndex("RaceId", "SubraceId")
                        .IsUnique()
                        .HasFilter("[SubraceId] IS NOT NULL");

                    b.ToTable("RaceRelations", (string)null);
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

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Character", b =>
                {
                    b.HasOne("UDMT.Domain.Entity.CharacterClass", "CharacterClass")
                        .WithMany()
                        .HasForeignKey("CharacterClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UDMT.Domain.Entity.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CharacterClass");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.CharacterAttribute", b =>
                {
                    b.HasOne("UDMT.Domain.Entity.Character", "Character")
                        .WithMany("Attributes")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.CharacterSavingThrow", b =>
                {
                    b.HasOne("UDMT.Domain.Entity.Character", "Character")
                        .WithMany("SavingThrows")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.CharacterSkill", b =>
                {
                    b.HasOne("UDMT.Domain.Entity.Character", "Character")
                        .WithMany("Skills")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UDMT.Domain.Entity.Skill", "Skill")
                        .WithMany("CharacterSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.ClassSavingThrow", b =>
                {
                    b.HasOne("UDMT.Domain.Entity.CharacterClass", "CharacterClass")
                        .WithMany("SavingThrowProficiencies")
                        .HasForeignKey("CharacterClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CharacterClass");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.RaceAttributeBonus", b =>
                {
                    b.HasOne("UDMT.Domain.Entity.Race", "Race")
                        .WithMany("AttributeBonuses")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Race");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.RaceRelation", b =>
                {
                    b.HasOne("UDMT.Domain.Entity.Race", "Race")
                        .WithMany("RaceRelations")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UDMT.Domain.Entity.Race", "Subrace")
                        .WithMany()
                        .HasForeignKey("SubraceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Race");

                    b.Navigation("Subrace");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Character", b =>
                {
                    b.Navigation("Attributes");

                    b.Navigation("SavingThrows");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.CharacterClass", b =>
                {
                    b.Navigation("SavingThrowProficiencies");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Race", b =>
                {
                    b.Navigation("AttributeBonuses");

                    b.Navigation("RaceRelations");
                });

            modelBuilder.Entity("UDMT.Domain.Entity.Skill", b =>
                {
                    b.Navigation("CharacterSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
