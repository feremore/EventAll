using Microsoft.EntityFrameworkCore.Migrations;

namespace EventAll.Data.Migrations
{
    public partial class EventProPro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Events_EventID",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "EventID",
                table: "Items",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CurrentEventId",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Events_EventID",
                table: "Items",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Events_EventID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CurrentEventId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "EventID",
                table: "Items",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Events_EventID",
                table: "Items",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
