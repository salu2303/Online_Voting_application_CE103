using Microsoft.EntityFrameworkCore.Migrations;

namespace demo2.Data.Migrations
{
    public partial class four : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "result",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cid = table.Column<int>(nullable: false),
                    vtypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_result", x => x.Id);
                    table.ForeignKey(
                        name: "FK_result_vtype_vtypeId",
                        column: x => x.vtypeId,
                        principalTable: "vtype",
                        principalColumn: "vtypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_result_vtypeId",
                table: "result",
                column: "vtypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "result");
        }
    }
}
