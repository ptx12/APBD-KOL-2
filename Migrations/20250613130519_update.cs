using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExampleTest2.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exhibition_Galleries_GalleryId",
                table: "Exhibition");

            migrationBuilder.DropForeignKey(
                name: "FK_Exhibition_Artwork_Exhibition_ExhibitionId",
                table: "Exhibition_Artwork");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exhibition",
                table: "Exhibition");

            migrationBuilder.RenameTable(
                name: "Exhibition",
                newName: "Exhibitions");

            migrationBuilder.RenameIndex(
                name: "IX_Exhibition_GalleryId",
                table: "Exhibitions",
                newName: "IX_Exhibitions_GalleryId");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exhibitions",
                table: "Exhibitions",
                column: "ExhibitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exhibition_Artwork_Exhibitions_ExhibitionId",
                table: "Exhibition_Artwork",
                column: "ExhibitionId",
                principalTable: "Exhibitions",
                principalColumn: "ExhibitionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exhibitions_Galleries_GalleryId",
                table: "Exhibitions",
                column: "GalleryId",
                principalTable: "Galleries",
                principalColumn: "GalleryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exhibition_Artwork_Exhibitions_ExhibitionId",
                table: "Exhibition_Artwork");

            migrationBuilder.DropForeignKey(
                name: "FK_Exhibitions_Galleries_GalleryId",
                table: "Exhibitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exhibitions",
                table: "Exhibitions");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Exhibitions",
                newName: "Exhibition");

            migrationBuilder.RenameIndex(
                name: "IX_Exhibitions_GalleryId",
                table: "Exhibition",
                newName: "IX_Exhibition_GalleryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exhibition",
                table: "Exhibition",
                column: "ExhibitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exhibition_Galleries_GalleryId",
                table: "Exhibition",
                column: "GalleryId",
                principalTable: "Galleries",
                principalColumn: "GalleryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exhibition_Artwork_Exhibition_ExhibitionId",
                table: "Exhibition_Artwork",
                column: "ExhibitionId",
                principalTable: "Exhibition",
                principalColumn: "ExhibitionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
