using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonelListesi.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depart_Users_UserID",
                table: "Depart");

            migrationBuilder.DropIndex(
                name: "IX_Depart_UserID",
                table: "Depart");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Depart");

            migrationBuilder.CreateTable(
                name: "AdminUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<int>(type: "int", nullable: false),
                    departman = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUsers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminUsers");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Depart",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Depart_UserID",
                table: "Depart",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Depart_Users_UserID",
                table: "Depart",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
