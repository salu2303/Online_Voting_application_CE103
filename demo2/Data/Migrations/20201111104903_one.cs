using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace demo2.Data.Migrations
{
    public partial class one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "no",
                table: "votingType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "addvoter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    votingTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addvoter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_addvoter_votingType_votingTypeId",
                        column: x => x.votingTypeId,
                        principalTable: "votingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vtype",
                columns: table => new
                {
                    vtypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    voting_type = table.Column<string>(nullable: false),
                    start_date = table.Column<DateTime>(nullable: false),
                    end_date = table.Column<DateTime>(nullable: false),
                    no = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vtype", x => x.vtypeId);
                });

            migrationBuilder.CreateTable(
                name: "avoter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    vtypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avoter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_avoter_vtype_vtypeId",
                        column: x => x.vtypeId,
                        principalTable: "vtype",
                        principalColumn: "vtypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cand",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    profession = table.Column<string>(nullable: true),
                    vtypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cand_vtype_vtypeId",
                        column: x => x.vtypeId,
                        principalTable: "vtype",
                        principalColumn: "vtypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_addvoter_votingTypeId",
                table: "addvoter",
                column: "votingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_avoter_vtypeId",
                table: "avoter",
                column: "vtypeId");

            migrationBuilder.CreateIndex(
                name: "IX_cand_vtypeId",
                table: "cand",
                column: "vtypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addvoter");

            migrationBuilder.DropTable(
                name: "avoter");

            migrationBuilder.DropTable(
                name: "cand");

            migrationBuilder.DropTable(
                name: "vtype");

            migrationBuilder.DropColumn(
                name: "no",
                table: "votingType");
        }
    }
}
