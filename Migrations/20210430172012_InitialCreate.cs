using Microsoft.EntityFrameworkCore.Migrations;

namespace LabNotes.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compounds",
                columns: table => new
                {
                    CompoundId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Brutto = table.Column<string>(type: "TEXT", nullable: true),
                    IUPACName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compounds", x => x.CompoundId);
                });

            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AtomNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Symbol = table.Column<string>(type: "TEXT", nullable: true),
                    MolarMass = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.ElementId);
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    ReactionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => x.ReactionId);
                });

            migrationBuilder.CreateTable(
                name: "CompoundReaction",
                columns: table => new
                {
                    CompoundReactionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompoundId = table.Column<int>(type: "INTEGER", nullable: true),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    Equivalents = table.Column<int>(type: "INTEGER", nullable: false),
                    IsLimiting = table.Column<bool>(type: "INTEGER", nullable: false),
                    ReactionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompoundReaction", x => x.CompoundReactionId);
                    table.ForeignKey(
                        name: "FK_CompoundReaction_Compounds_CompoundId",
                        column: x => x.CompoundId,
                        principalTable: "Compounds",
                        principalColumn: "CompoundId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompoundReaction_Reactions_ReactionId",
                        column: x => x.ReactionId,
                        principalTable: "Reactions",
                        principalColumn: "ReactionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompoundReaction_CompoundId",
                table: "CompoundReaction",
                column: "CompoundId");

            migrationBuilder.CreateIndex(
                name: "IX_CompoundReaction_ReactionId",
                table: "CompoundReaction",
                column: "ReactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompoundReaction");

            migrationBuilder.DropTable(
                name: "Elements");

            migrationBuilder.DropTable(
                name: "Compounds");

            migrationBuilder.DropTable(
                name: "Reactions");
        }
    }
}
