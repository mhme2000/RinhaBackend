using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RinhaBackend.Migrations
{
    public partial class AddGeneratedColumn2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Stacks",
                table: "Person",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(List<string>),
                oldType: "text[]",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SearchText",
                table: "Person",
                type: "text",
                nullable: false,
                computedColumnSql: "(lower(\"Person\".\"Surname\" || \"Person\".\"Name\" || \"Person\".\"Stacks\"))",
                stored: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldComputedColumnSql: "ARRAY_TO_STRING([Surname, Name, Stacks], ' ')",
                oldStored: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<List<string>>(
                name: "Stacks",
                table: "Person",
                type: "text[]",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "SearchText",
                table: "Person",
                type: "text",
                nullable: false,
                computedColumnSql: "ARRAY_TO_STRING([Surname, Name, Stacks], ' ')",
                stored: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldComputedColumnSql: "(lower(\"Person\".\"Surname\" || \"Person\".\"Name\" || \"Person\".\"Stacks\"))",
                oldStored: true);
        }
    }
}
