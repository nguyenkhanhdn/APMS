using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APMS.Migrations
{
    /// <inheritdoc />
    public partial class somechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingTransactions_ParkingSlots_SlotId",
                table: "ParkingTransactions");

            migrationBuilder.RenameColumn(
                name: "SlotId",
                table: "ParkingTransactions",
                newName: "ParkingSlotId");

            migrationBuilder.RenameIndex(
                name: "IX_ParkingTransactions_SlotId",
                table: "ParkingTransactions",
                newName: "IX_ParkingTransactions_ParkingSlotId");

            migrationBuilder.AddColumn<string>(
                name: "Balance",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingTransactions_ParkingSlots_ParkingSlotId",
                table: "ParkingTransactions",
                column: "ParkingSlotId",
                principalTable: "ParkingSlots",
                principalColumn: "ParkingSlotId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingTransactions_ParkingSlots_ParkingSlotId",
                table: "ParkingTransactions");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ParkingSlotId",
                table: "ParkingTransactions",
                newName: "SlotId");

            migrationBuilder.RenameIndex(
                name: "IX_ParkingTransactions_ParkingSlotId",
                table: "ParkingTransactions",
                newName: "IX_ParkingTransactions_SlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingTransactions_ParkingSlots_SlotId",
                table: "ParkingTransactions",
                column: "SlotId",
                principalTable: "ParkingSlots",
                principalColumn: "ParkingSlotId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
