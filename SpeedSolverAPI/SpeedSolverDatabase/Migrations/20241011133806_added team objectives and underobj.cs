using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SpeedSolverDatabase.Migrations
{
    /// <inheritdoc />
    public partial class addedteamobjectivesandunderobj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ObjectiveId",
                table: "objectives",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateTable(
                name: "teamobjectives",
                columns: table => new
                {
                    TeamObjectiveId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    ObjectiveId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teamobjectives", x => x.TeamObjectiveId);
                    table.ForeignKey(
                        name: "FK_teamobjectives_teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "underobjectives",
                columns: table => new
                {
                    UnderObjectiveId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UnderObjectiveTitle = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    GeneralObjectiveId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_underobjectives", x => x.UnderObjectiveId);
                    table.ForeignKey(
                        name: "FK_underobjectives_objectives_GeneralObjectiveId",
                        column: x => x.GeneralObjectiveId,
                        principalTable: "objectives",
                        principalColumn: "ObjectiveId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_teamobjectives_TeamId",
                table: "teamobjectives",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_underobjectives_GeneralObjectiveId",
                table: "underobjectives",
                column: "GeneralObjectiveId");

            migrationBuilder.AddForeignKey(
                name: "FK_objectives_teamobjectives_ObjectiveId",
                table: "objectives",
                column: "ObjectiveId",
                principalTable: "teamobjectives",
                principalColumn: "TeamObjectiveId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_objectives_teamobjectives_ObjectiveId",
                table: "objectives");

            migrationBuilder.DropTable(
                name: "teamobjectives");

            migrationBuilder.DropTable(
                name: "underobjectives");

            migrationBuilder.AlterColumn<int>(
                name: "ObjectiveId",
                table: "objectives",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
