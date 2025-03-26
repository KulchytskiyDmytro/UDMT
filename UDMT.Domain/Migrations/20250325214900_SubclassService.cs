using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UDMT.Domain.Migrations
{
    /// <inheritdoc />
    public partial class SubclassService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharSubclassId",
                table: "Features",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasMagic",
                table: "CharClasses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHomebrew",
                table: "CharClasses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SubclassId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CharSubclasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsHomebrew = table.Column<bool>(type: "bit", nullable: false),
                    GrantsMagic = table.Column<bool>(type: "bit", nullable: false),
                    CharClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharSubclasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharSubclasses_CharClasses_CharClassId",
                        column: x => x.CharClassId,
                        principalTable: "CharClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Features_CharSubclassId",
                table: "Features",
                column: "CharSubclassId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_SubclassId",
                table: "Characters",
                column: "SubclassId");

            migrationBuilder.CreateIndex(
                name: "IX_CharSubclasses_CharClassId",
                table: "CharSubclasses",
                column: "CharClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CharSubclasses_SubclassId",
                table: "Characters",
                column: "SubclassId",
                principalTable: "CharSubclasses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_CharSubclasses_CharSubclassId",
                table: "Features",
                column: "CharSubclassId",
                principalTable: "CharSubclasses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharSubclasses_SubclassId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Features_CharSubclasses_CharSubclassId",
                table: "Features");

            migrationBuilder.DropTable(
                name: "CharSubclasses");

            migrationBuilder.DropIndex(
                name: "IX_Features_CharSubclassId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Characters_SubclassId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CharSubclassId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "HasMagic",
                table: "CharClasses");

            migrationBuilder.DropColumn(
                name: "IsHomebrew",
                table: "CharClasses");

            migrationBuilder.DropColumn(
                name: "SubclassId",
                table: "Characters");
        }
    }
}
