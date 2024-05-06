using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Pustok.Migrations
{
    /// <inheritdoc />
    public partial class AuditEntityAddedddsdsda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Books",
                newName: "Deleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Books",
                newName: "IsDeleted");
        }
    }
}
