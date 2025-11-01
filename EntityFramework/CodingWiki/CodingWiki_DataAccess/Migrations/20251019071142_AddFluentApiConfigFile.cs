using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddFluentApiConfigFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentAuthorBook_Fluent_Authors_Author_Id",
                table: "FluentAuthorBook");

            migrationBuilder.DropForeignKey(
                name: "FK_FluentAuthorBook_Fluent_Book_BookId",
                table: "FluentAuthorBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FluentAuthorBook",
                table: "FluentAuthorBook");

            migrationBuilder.RenameTable(
                name: "FluentAuthorBook",
                newName: "FluentAuthorBooks");

            migrationBuilder.RenameIndex(
                name: "IX_FluentAuthorBook_BookId",
                table: "FluentAuthorBooks",
                newName: "IX_FluentAuthorBooks_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FluentAuthorBooks",
                table: "FluentAuthorBooks",
                columns: new[] { "Author_Id", "BookId" });

            migrationBuilder.CreateTable(
                name: "tblAuthor",
                columns: table => new
                {
                    Author_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAuthor", x => x.Author_Id);
                });

            migrationBuilder.CreateTable(
                name: "tblPublisher",
                columns: table => new
                {
                    Publisher_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPublisher", x => x.Publisher_Id);
                });

            migrationBuilder.CreateTable(
                name: "tblBook",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Publisher_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBook", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_tblBook_tblPublisher_Publisher_Id",
                        column: x => x.Publisher_Id,
                        principalTable: "tblPublisher",
                        principalColumn: "Publisher_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblAuthorBook",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Author_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAuthorBook", x => new { x.Author_Id, x.BookId });
                    table.ForeignKey(
                        name: "FK_tblAuthorBook_tblAuthor_BookId",
                        column: x => x.BookId,
                        principalTable: "tblAuthor",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblAuthorBook_tblBook_Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "tblBook",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblBookDetails",
                columns: table => new
                {
                    BookDetail_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfChapters = table.Column<int>(type: "int", nullable: false),
                    NumberOfPages = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBookDetails", x => x.BookDetail_Id);
                    table.ForeignKey(
                        name: "FK_tblBookDetails_tblBook_BookId",
                        column: x => x.BookId,
                        principalTable: "tblBook",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAuthorBook_BookId",
                table: "tblAuthorBook",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_tblBook_Publisher_Id",
                table: "tblBook",
                column: "Publisher_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tblBookDetails_BookId",
                table: "tblBookDetails",
                column: "BookId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentAuthorBooks_Fluent_Authors_Author_Id",
                table: "FluentAuthorBooks",
                column: "Author_Id",
                principalTable: "Fluent_Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentAuthorBooks_Fluent_Book_BookId",
                table: "FluentAuthorBooks",
                column: "BookId",
                principalTable: "Fluent_Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentAuthorBooks_Fluent_Authors_Author_Id",
                table: "FluentAuthorBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_FluentAuthorBooks_Fluent_Book_BookId",
                table: "FluentAuthorBooks");

            migrationBuilder.DropTable(
                name: "tblAuthorBook");

            migrationBuilder.DropTable(
                name: "tblBookDetails");

            migrationBuilder.DropTable(
                name: "tblAuthor");

            migrationBuilder.DropTable(
                name: "tblBook");

            migrationBuilder.DropTable(
                name: "tblPublisher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FluentAuthorBooks",
                table: "FluentAuthorBooks");

            migrationBuilder.RenameTable(
                name: "FluentAuthorBooks",
                newName: "FluentAuthorBook");

            migrationBuilder.RenameIndex(
                name: "IX_FluentAuthorBooks_BookId",
                table: "FluentAuthorBook",
                newName: "IX_FluentAuthorBook_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FluentAuthorBook",
                table: "FluentAuthorBook",
                columns: new[] { "Author_Id", "BookId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FluentAuthorBook_Fluent_Authors_Author_Id",
                table: "FluentAuthorBook",
                column: "Author_Id",
                principalTable: "Fluent_Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentAuthorBook_Fluent_Book_BookId",
                table: "FluentAuthorBook",
                column: "BookId",
                principalTable: "Fluent_Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
