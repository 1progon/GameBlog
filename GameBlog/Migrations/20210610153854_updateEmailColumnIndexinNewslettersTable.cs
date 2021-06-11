using Microsoft.EntityFrameworkCore.Migrations;

namespace GameBlog.Migrations
{
    public partial class updateEmailColumnIndexinNewslettersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Newsletters",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Newsletters_Email",
                table: "Newsletters",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Newsletters_Email",
                table: "Newsletters");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Newsletters",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
