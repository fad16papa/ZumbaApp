using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZumbaAPI.Migrations
{
    public partial class UpdatePricingModelAndActivityModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ActivitiesModelId",
                table: "PricingModels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PriceDescription",
                table: "PricingModels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActivityDescription",
                table: "ActivitiesModels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "ActivitiesModels",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PricingModels_ActivitiesModelId",
                table: "PricingModels",
                column: "ActivitiesModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesModels_ApplicationUserId",
                table: "ActivitiesModels",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivitiesModels_AspNetUsers_ApplicationUserId",
                table: "ActivitiesModels",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PricingModels_ActivitiesModels_ActivitiesModelId",
                table: "PricingModels",
                column: "ActivitiesModelId",
                principalTable: "ActivitiesModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivitiesModels_AspNetUsers_ApplicationUserId",
                table: "ActivitiesModels");

            migrationBuilder.DropForeignKey(
                name: "FK_PricingModels_ActivitiesModels_ActivitiesModelId",
                table: "PricingModels");

            migrationBuilder.DropIndex(
                name: "IX_PricingModels_ActivitiesModelId",
                table: "PricingModels");

            migrationBuilder.DropIndex(
                name: "IX_ActivitiesModels_ApplicationUserId",
                table: "ActivitiesModels");

            migrationBuilder.DropColumn(
                name: "ActivitiesModelId",
                table: "PricingModels");

            migrationBuilder.DropColumn(
                name: "PriceDescription",
                table: "PricingModels");

            migrationBuilder.DropColumn(
                name: "ActivityDescription",
                table: "ActivitiesModels");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ActivitiesModels");
        }
    }
}
