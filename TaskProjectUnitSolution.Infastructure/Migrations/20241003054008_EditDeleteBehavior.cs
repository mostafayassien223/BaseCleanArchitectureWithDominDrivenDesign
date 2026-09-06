using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskProjectUnitSolution.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Projects_ProjectId",
                table: "Units");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Projects_ProjectId",
                table: "Units",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Projects_ProjectId",
                table: "Units");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Projects_ProjectId",
                table: "Units",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
