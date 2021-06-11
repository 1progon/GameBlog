using Microsoft.EntityFrameworkCore.Migrations;

namespace GameBlog.Migrations
{
    public partial class changeImageColumnTypeInBlogPostsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "BlogPosts",
                type: "varchar(255)",
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "BlogPosts",
                type: "text",
                oldType: "varchar(255)");
        }
    }
}
