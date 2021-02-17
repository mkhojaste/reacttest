using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class SetRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "QueueId",
                table: "Turns",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Turns_QueueId",
                table: "Turns",
                column: "QueueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Turns_Queues_QueueId",
                table: "Turns",
                column: "QueueId",
                principalTable: "Queues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turns_Queues_QueueId",
                table: "Turns");

            migrationBuilder.DropIndex(
                name: "IX_Turns_QueueId",
                table: "Turns");

            migrationBuilder.DropColumn(
                name: "QueueId",
                table: "Turns");
        }
    }
}
