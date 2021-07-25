using Microsoft.EntityFrameworkCore.Migrations;

namespace ApaYah.Migrations
{
    public partial class blog_validation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Blog",
                type: "varchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Blog",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(12)",
                oldMaxLength: 12);
        }
    }
}
