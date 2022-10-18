using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Todos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "FirstName", "LastName", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 18, 9, 8, 59, 524, DateTimeKind.Local).AddTicks(4052), "Ali", "Veli", null },
                    { 2, new DateTime(2022, 10, 18, 9, 8, 59, 524, DateTimeKind.Local).AddTicks(4104), "Ayşe", "Fatma", null },
                    { 3, new DateTime(2022, 10, 18, 9, 8, 59, 524, DateTimeKind.Local).AddTicks(4110), "Ali", "Cengiz", null },
                    { 4, new DateTime(2022, 10, 18, 9, 8, 59, 524, DateTimeKind.Local).AddTicks(4111), "John", "Doe", null }
                });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Content", "CreatedDate", "Date", "IsDone", "Title", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, "iki ekmek al ve eve git.", new DateTime(2022, 10, 18, 9, 8, 59, 524, DateTimeKind.Local).AddTicks(4586), new DateTime(2022, 10, 18, 9, 8, 59, 524, DateTimeKind.Local).AddTicks(4585), false, "Ekmek", null, 1 },
                    { 2, "süt al.", new DateTime(2022, 10, 18, 9, 8, 59, 524, DateTimeKind.Local).AddTicks(4589), new DateTime(2022, 10, 18, 9, 8, 59, 524, DateTimeKind.Local).AddTicks(4588), false, "Süt", null, 2 },
                    { 3, "yoğurt al.", new DateTime(2022, 10, 18, 9, 8, 59, 524, DateTimeKind.Local).AddTicks(4591), new DateTime(2022, 10, 18, 9, 8, 59, 524, DateTimeKind.Local).AddTicks(4590), false, "Yoğurt", null, 3 },
                    { 4, "un al.", new DateTime(2022, 10, 18, 9, 8, 59, 524, DateTimeKind.Local).AddTicks(4592), new DateTime(2022, 10, 18, 9, 8, 59, 524, DateTimeKind.Local).AddTicks(4592), false, "Un", null, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_UserId",
                table: "Todos",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Todos");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
