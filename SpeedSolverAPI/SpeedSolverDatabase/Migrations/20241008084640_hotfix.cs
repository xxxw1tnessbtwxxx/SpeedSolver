using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpeedSolverDatabase.Migrations
{
    /// <inheritdoc />
    public partial class hotfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Objective_Users_CreatorId",
                table: "Objective");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamObjective_Teams_TeamId",
                table: "TeamObjective");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Users_CreatorId",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamObjective",
                table: "TeamObjective");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Objective",
                table: "Objective");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "teams");

            migrationBuilder.RenameTable(
                name: "TeamObjective",
                newName: "teamsobjectives");

            migrationBuilder.RenameTable(
                name: "Objective",
                newName: "objectives");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_CreatorId",
                table: "teams",
                newName: "IX_teams_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamObjective_TeamId",
                table: "teamsobjectives",
                newName: "IX_teamsobjectives_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Objective_CreatorId",
                table: "objectives",
                newName: "IX_objectives_CreatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_teams",
                table: "teams",
                column: "TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_teamsobjectives",
                table: "teamsobjectives",
                column: "TeamTaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_objectives",
                table: "objectives",
                column: "ObjectiveId");

            migrationBuilder.AddForeignKey(
                name: "FK_objectives_users_CreatorId",
                table: "objectives",
                column: "CreatorId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teams_users_CreatorId",
                table: "teams",
                column: "CreatorId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teamsobjectives_teams_TeamId",
                table: "teamsobjectives",
                column: "TeamId",
                principalTable: "teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_objectives_users_CreatorId",
                table: "objectives");

            migrationBuilder.DropForeignKey(
                name: "FK_teams_users_CreatorId",
                table: "teams");

            migrationBuilder.DropForeignKey(
                name: "FK_teamsobjectives_teams_TeamId",
                table: "teamsobjectives");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_teams",
                table: "teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_teamsobjectives",
                table: "teamsobjectives");

            migrationBuilder.DropPrimaryKey(
                name: "PK_objectives",
                table: "objectives");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "teams",
                newName: "Teams");

            migrationBuilder.RenameTable(
                name: "teamsobjectives",
                newName: "TeamObjective");

            migrationBuilder.RenameTable(
                name: "objectives",
                newName: "Objective");

            migrationBuilder.RenameIndex(
                name: "IX_teams_CreatorId",
                table: "Teams",
                newName: "IX_Teams_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_teamsobjectives_TeamId",
                table: "TeamObjective",
                newName: "IX_TeamObjective_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_objectives_CreatorId",
                table: "Objective",
                newName: "IX_Objective_CreatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamObjective",
                table: "TeamObjective",
                column: "TeamTaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Objective",
                table: "Objective",
                column: "ObjectiveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Objective_Users_CreatorId",
                table: "Objective",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamObjective_Teams_TeamId",
                table: "TeamObjective",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Users_CreatorId",
                table: "Teams",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
