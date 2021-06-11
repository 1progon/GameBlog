using Microsoft.EntityFrameworkCore.Migrations;

namespace GameBlog.Migrations
{
    public partial class addImageColumnInBlogPostsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "BlogPosts",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "BlogPosts");
        }
    }
}
