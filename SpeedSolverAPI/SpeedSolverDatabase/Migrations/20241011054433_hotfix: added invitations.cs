using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpeedSolverDatabase.Migrations
{
    /// <inheritdoc />
    public partial class hotfixaddedinvitations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvitedByLeaderId",
                table: "invitations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_invitations_InvitedByLeaderId",
                table: "invitations",
                column: "InvitedByLeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_invitations_users_InvitedByLeaderId",
                table: "invitations",
                column: "InvitedByLeaderId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invitations_users_InvitedByLeaderId",
                table: "invitations");

            migrationBuilder.DropIndex(
                name: "IX_invitations_InvitedByLeaderId",
                table: "invitations");

            migrationBuilder.DropColumn(
                name: "InvitedByLeaderId",
                table: "invitations");
        }
    }
}
