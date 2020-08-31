using Microsoft.EntityFrameworkCore.Migrations;

namespace ZumbaAPI.Migrations
{
    public partial class UpdateActivityAndPriceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PricingModels",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ActivitiesModels",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PricingModels");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ActivitiesModels");
        }
    }
}
