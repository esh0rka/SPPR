using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_153504_Gaikevich.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoPart_Category_CategoryId",
                table: "AutoPart");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Category",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "AutoPart",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_CategoryId",
                table: "Category",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AutoPart_Category_CategoryId",
                table: "AutoPart",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_CategoryId",
                table: "Category",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoPart_Category_CategoryId",
                table: "AutoPart");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_CategoryId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_CategoryId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Category");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "AutoPart",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_AutoPart_Category_CategoryId",
                table: "AutoPart",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }
    }
}
