using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZumbaAPI.Migrations
{
    public partial class UpdateApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PricingModelId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PricingModelId",
                table: "AspNetUsers",
                column: "PricingModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PricingModels_PricingModelId",
                table: "AspNetUsers",
                column: "PricingModelId",
                principalTable: "PricingModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PricingModels_PricingModelId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PricingModelId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PricingModelId",
                table: "AspNetUsers");
        }
    }
}
