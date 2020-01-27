using Microsoft.EntityFrameworkCore.Migrations;

namespace EventAll.Data.Migrations
{
    public partial class EventPro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventVenues");

            migrationBuilder.AddColumn<int>(
                name: "Hours",
                table: "EventStaffs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VenueID",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EventEquipments",
                columns: table => new
                {
                    EventID = table.Column<int>(nullable: false),
                    EquipmentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventEquipments", x => new { x.EventID, x.EquipmentID });
                    table.ForeignKey(
                        name: "FK_EventEquipments_Equipments_EquipmentID",
                        column: x => x.EquipmentID,
                        principalTable: "Equipments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventEquipments_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentID = table.Column<int>(nullable: false),
                    EventID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Items_Equipments_EquipmentID",
                        column: x => x.EquipmentID,
                        principalTable: "Equipments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_VenueID",
                table: "Events",
                column: "VenueID");

            migrationBuilder.CreateIndex(
                name: "IX_EventEquipments_EquipmentID",
                table: "EventEquipments",
                column: "EquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_EquipmentID",
                table: "Items",
                column: "EquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_EventID",
                table: "Items",
                column: "EventID");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Venues_VenueID",
                table: "Events",
                column: "VenueID",
                principalTable: "Venues",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Venues_VenueID",
                table: "Events");

            migrationBuilder.DropTable(
                name: "EventEquipments");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Events_VenueID",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Hours",
                table: "EventStaffs");

            migrationBuilder.DropColumn(
                name: "VenueID",
                table: "Events");

            migrationBuilder.CreateTable(
                name: "EventVenues",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false),
                    VenueID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventVenues", x => new { x.EventID, x.VenueID });
                    table.ForeignKey(
                        name: "FK_EventVenues_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventVenues_Venues_VenueID",
                        column: x => x.VenueID,
                        principalTable: "Venues",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventVenues_VenueID",
                table: "EventVenues",
                column: "VenueID");
        }
    }
}
