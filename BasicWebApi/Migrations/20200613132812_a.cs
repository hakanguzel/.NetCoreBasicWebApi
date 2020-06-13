using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BasicWebApi.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StickyNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StickyNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StickyNotes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { new Guid("26f4e1ac-e426-421e-b2ea-e759500430f3"), "FirstName1", "LastName1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { new Guid("6f793c05-8555-4090-a411-b16fdff9e5f1"), "FirstName2", "LastName2" });

            migrationBuilder.InsertData(
                table: "StickyNotes",
                columns: new[] { "Id", "Note", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("4469ec5f-b8ba-45e7-b144-a36fbcc48827"), "Test Note1", "Test Title1", new Guid("26f4e1ac-e426-421e-b2ea-e759500430f3") },
                    { new Guid("1657de06-3e16-4ac7-8b9d-fc1359d1ddc6"), "Test Note2", "Test Title2", new Guid("26f4e1ac-e426-421e-b2ea-e759500430f3") },
                    { new Guid("1fd849e2-f3b0-4a80-a7dd-32f47de67fcf"), "Test Note3", "Test Title3", new Guid("6f793c05-8555-4090-a411-b16fdff9e5f1") },
                    { new Guid("48b06430-5ae0-4420-bb3a-0bbf5a528c7f"), "Test Note4", "Test Title4", new Guid("6f793c05-8555-4090-a411-b16fdff9e5f1") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StickyNotes_UserId",
                table: "StickyNotes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StickyNotes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
