using Microsoft.EntityFrameworkCore.Migrations;

namespace Dependent.Migrations
{
    public partial class Dependent2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_Parent_ParentId",
                schema: "Dependent",
                table: "Children");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_Parent_ParentId",
                schema: "Dependent",
                table: "Children");
        }
    }
}
