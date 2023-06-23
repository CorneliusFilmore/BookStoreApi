using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookStoreApi.Migrations
{
    /// <inheritdoc />
    public partial class AddAdvertTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdvertId",
                table: "Books",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Adverts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adverts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AdvertId",
                table: "Books",
                column: "AdvertId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Adverts_AdvertId",
                table: "Books",
                column: "AdvertId",
                principalTable: "Adverts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Adverts_AdvertId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Adverts");

            migrationBuilder.DropIndex(
                name: "IX_Books_AdvertId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AdvertId",
                table: "Books");
        }
    }
}
