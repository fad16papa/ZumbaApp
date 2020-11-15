using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class UpdateBlogEntityandaddBlogPhotoEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Blogs_BlogId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_BlogId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "Photos");

            migrationBuilder.CreateTable(
                name: "BlogPhoto",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    IsMain = table.Column<bool>(nullable: false),
                    BlogId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPhoto_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPhoto_BlogId",
                table: "BlogPhoto",
                column: "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPhoto");

            migrationBuilder.AddColumn<Guid>(
                name: "BlogId",
                table: "Photos",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_BlogId",
                table: "Photos",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Blogs_BlogId",
                table: "Photos",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
