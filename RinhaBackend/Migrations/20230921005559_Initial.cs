using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RinhaBackend.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<string>(type: "text", nullable: false),
                    Stacks = table.Column<string>(type: "text", nullable: false),
                    SearchText = table.Column<string>(type: "text", nullable: false, computedColumnSql: "(lower(\"Person\".\"Surname\" || \"Person\".\"Name\" || \"Person\".\"Stacks\"))", stored: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
