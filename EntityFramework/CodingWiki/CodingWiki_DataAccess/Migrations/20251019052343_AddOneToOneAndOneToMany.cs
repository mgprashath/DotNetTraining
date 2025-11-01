using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddOneToOneAndOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Publisher_Id",
                table: "Fluent_Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FluentAuthorBook",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Author_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentAuthorBook", x => new { x.Author_Id, x.BookId });
                    table.ForeignKey(
                        name: "FK_FluentAuthorBook_Fluent_Authors_Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "Fluent_Authors",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FluentAuthorBook_Fluent_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Fluent_Book",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_BookDetails_BookId",
                table: "Fluent_BookDetails",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Book_Publisher_Id",
                table: "Fluent_Book",
                column: "Publisher_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FluentAuthorBook_BookId",
                table: "FluentAuthorBook",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Book_Fluent_Publishers_Publisher_Id",
                table: "Fluent_Book",
                column: "Publisher_Id",
                principalTable: "Fluent_Publishers",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookDetails_Fluent_Book_BookId",
                table: "Fluent_BookDetails",
                column: "BookId",
                principalTable: "Fluent_Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Book_Fluent_Publishers_Publisher_Id",
                table: "Fluent_Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookDetails_Fluent_Book_BookId",
                table: "Fluent_BookDetails");

            migrationBuilder.DropTable(
                name: "FluentAuthorBook");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_BookDetails_BookId",
                table: "Fluent_BookDetails");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Book_Publisher_Id",
                table: "Fluent_Book");

            migrationBuilder.DropColumn(
                name: "Publisher_Id",
                table: "Fluent_Book");
        }
    }
}
