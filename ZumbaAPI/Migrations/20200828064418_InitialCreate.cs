using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZumbaAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivitiesModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ActivityName = table.Column<string>(nullable: true),
                    ActivityLink = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitiesModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PricingModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PriceName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricingModels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivitiesModels");

            migrationBuilder.DropTable(
                name: "PricingModels");
        }
    }
}
