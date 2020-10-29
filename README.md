# EFToolingExcludeFromMigrationsIssue
Example repository for EF Tooling issue

Dependent2 will already have the below issues but run the following command to repreoduce it


cd Dependent
dotnet ef migrations add Depenedent3



**This will generate the migration** 

    using Microsoft.EntityFrameworkCore.Migrations;

    namespace Dependent.Migrations
    {
        public partial class depenedent3 : Migration
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


This migration should not touch the FK, but even if it does it should add it back again.

**Second issue**  

Both the designer.cs and the snapshot.cs are generated with errors

    b1.ToTable("Children", "Dependent", t => t.ExcludeFromMigrations());

t does not have a method ExcludeFromMigrations() on it and won't compile