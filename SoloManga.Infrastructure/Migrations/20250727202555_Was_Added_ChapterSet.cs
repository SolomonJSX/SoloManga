using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoloManga.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Was_Added_ChapterSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Chapter_LastReadChapterId",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Chapter_Mangas_MangaId",
                table: "Chapter");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Chapter_ChapterId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Chapter_ChapterId",
                table: "Pages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chapter",
                table: "Chapter");

            migrationBuilder.RenameTable(
                name: "Chapter",
                newName: "Chapters");

            migrationBuilder.RenameIndex(
                name: "IX_Chapter_MangaId",
                table: "Chapters",
                newName: "IX_Chapters_MangaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chapters",
                table: "Chapters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Chapters_LastReadChapterId",
                table: "Bookmarks",
                column: "LastReadChapterId",
                principalTable: "Chapters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Mangas_MangaId",
                table: "Chapters",
                column: "MangaId",
                principalTable: "Mangas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Chapters_ChapterId",
                table: "Comments",
                column: "ChapterId",
                principalTable: "Chapters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Chapters_ChapterId",
                table: "Pages",
                column: "ChapterId",
                principalTable: "Chapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Chapters_LastReadChapterId",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Mangas_MangaId",
                table: "Chapters");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Chapters_ChapterId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Chapters_ChapterId",
                table: "Pages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chapters",
                table: "Chapters");

            migrationBuilder.RenameTable(
                name: "Chapters",
                newName: "Chapter");

            migrationBuilder.RenameIndex(
                name: "IX_Chapters_MangaId",
                table: "Chapter",
                newName: "IX_Chapter_MangaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chapter",
                table: "Chapter",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Chapter_LastReadChapterId",
                table: "Bookmarks",
                column: "LastReadChapterId",
                principalTable: "Chapter",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapter_Mangas_MangaId",
                table: "Chapter",
                column: "MangaId",
                principalTable: "Mangas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Chapter_ChapterId",
                table: "Comments",
                column: "ChapterId",
                principalTable: "Chapter",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Chapter_ChapterId",
                table: "Pages",
                column: "ChapterId",
                principalTable: "Chapter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
