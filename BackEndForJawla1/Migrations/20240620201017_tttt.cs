using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndForJawla1.Migrations
{
    /// <inheritdoc />
    public partial class tttt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userId",
                schema: "user",
                table: "user",
                newName: "userID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userID",
                schema: "user",
                table: "user",
                newName: "userId");
        }
    }
}
