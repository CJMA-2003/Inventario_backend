using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inventario.Migrations
{
    /// <inheritdoc />
    public partial class initial_migrations1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categorizations_categorizations_parent_id",
                table: "categorizations");

            migrationBuilder.AlterColumn<int>(
                name: "parent_id",
                table: "categorizations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_categorizations_categorizations_parent_id",
                table: "categorizations",
                column: "parent_id",
                principalTable: "categorizations",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categorizations_categorizations_parent_id",
                table: "categorizations");

            migrationBuilder.AlterColumn<int>(
                name: "parent_id",
                table: "categorizations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_categorizations_categorizations_parent_id",
                table: "categorizations",
                column: "parent_id",
                principalTable: "categorizations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
