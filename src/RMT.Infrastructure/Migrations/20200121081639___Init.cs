using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RMT.Infrastructure.Migrations
{
    public partial class __Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CVs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateName = table.Column<string>(nullable: true),
                    CandidateDoB = table.Column<DateTime>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    LevelId = table.Column<int>(nullable: true),
                    PositionId = table.Column<int>(nullable: true),
                    University = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    ApplyPositionNote = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    CVSource = table.Column<string>(nullable: true),
                    SalaryExpect = table.Column<float>(nullable: true),
                    SalaryOffer = table.Column<float>(nullable: true),
                    InComingDate = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CVs_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CVs_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CVId = table.Column<int>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    LastStatus = table.Column<string>(nullable: true),
                    NoteArchived = table.Column<string>(nullable: true),
                    Result = table.Column<string>(nullable: true),
                    FeedBackLink = table.Column<string>(nullable: true),
                    NoteOfBOD = table.Column<string>(nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rounds_CVs_CVId",
                        column: x => x.CVId,
                        principalTable: "CVs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRounds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoundId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRounds_Rounds_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Rounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRounds_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Intern" },
                    { 2, "Fresher" },
                    { 3, "Junior" },
                    { 4, "Senior" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name", "Note" },
                values: new object[,]
                {
                    { 1, ".NET", null },
                    { 2, "Java", null },
                    { 3, "PHP", null },
                    { 4, "JS", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "FullName", "PasswordHash", "Role", "UpdateAt", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 21, 15, 16, 39, 191, DateTimeKind.Local).AddTicks(7988), "AdminTest", "q+l3mg3u2+EYnCjgX4To3P8XfZuVXLHzzIqPD+3AkBU=", "Admin", new DateTime(2020, 1, 21, 15, 16, 39, 191, DateTimeKind.Local).AddTicks(8575), "Admin" },
                    { 2, new DateTime(2020, 1, 21, 15, 16, 39, 191, DateTimeKind.Local).AddTicks(9171), "HrTest", "q+l3mg3u2+EYnCjgX4To3P8XfZuVXLHzzIqPD+3AkBU=", "HR", new DateTime(2020, 1, 21, 15, 16, 39, 191, DateTimeKind.Local).AddTicks(9185), "Hr" },
                    { 3, new DateTime(2020, 1, 21, 15, 16, 39, 191, DateTimeKind.Local).AddTicks(9285), "InterViewer", "q+l3mg3u2+EYnCjgX4To3P8XfZuVXLHzzIqPD+3AkBU=", "Interviewer", new DateTime(2020, 1, 21, 15, 16, 39, 191, DateTimeKind.Local).AddTicks(9287), "Interviewer" }
                });

            migrationBuilder.InsertData(
                table: "CVs",
                columns: new[] { "Id", "Address", "ApplyPositionNote", "CVSource", "CandidateDoB", "CandidateName", "Gender", "InComingDate", "LevelId", "Note", "Path", "PositionId", "SalaryExpect", "SalaryOffer", "Status", "University", "UpdateAt" },
                values: new object[] { 1, "Ha Noi", "test", "web", new DateTime(2020, 1, 21, 15, 16, 39, 189, DateTimeKind.Local).AddTicks(7596), "Test", "Male", new DateTime(2020, 1, 21, 15, 16, 39, 188, DateTimeKind.Local).AddTicks(5696), 1, "test note", null, 1, 10000f, 20000f, "Not Process Yet", "PTIT", new DateTime(2020, 1, 21, 15, 16, 39, 189, DateTimeKind.Local).AddTicks(6976) });

            migrationBuilder.InsertData(
                table: "CVs",
                columns: new[] { "Id", "Address", "ApplyPositionNote", "CVSource", "CandidateDoB", "CandidateName", "Gender", "InComingDate", "LevelId", "Note", "Path", "PositionId", "SalaryExpect", "SalaryOffer", "Status", "University", "UpdateAt" },
                values: new object[] { 2, "Ha Noi", "test", "web", new DateTime(2020, 1, 21, 15, 16, 39, 189, DateTimeKind.Local).AddTicks(9571), "Test 2", "Male", new DateTime(2020, 1, 21, 15, 16, 39, 189, DateTimeKind.Local).AddTicks(9544), 2, "test note", null, 2, 150000f, 200000f, "Not Process Yet", "PTIT", new DateTime(2020, 1, 21, 15, 16, 39, 189, DateTimeKind.Local).AddTicks(9560) });

            migrationBuilder.InsertData(
                table: "CVs",
                columns: new[] { "Id", "Address", "ApplyPositionNote", "CVSource", "CandidateDoB", "CandidateName", "Gender", "InComingDate", "LevelId", "Note", "Path", "PositionId", "SalaryExpect", "SalaryOffer", "Status", "University", "UpdateAt" },
                values: new object[] { 3, "Ha Noi", "test", "web", new DateTime(2020, 1, 21, 15, 16, 39, 189, DateTimeKind.Local).AddTicks(9609), "Test 3", "Male", new DateTime(2020, 1, 21, 15, 16, 39, 189, DateTimeKind.Local).AddTicks(9605), 3, "test note", null, 3, 100000f, 120000f, "Not Process Yet", "PTIT", new DateTime(2020, 1, 21, 15, 16, 39, 189, DateTimeKind.Local).AddTicks(9607) });

            migrationBuilder.CreateIndex(
                name: "IX_CVs_LevelId",
                table: "CVs",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_CVs_PositionId",
                table: "CVs",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_CVId",
                table: "Rounds",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRounds_RoundId",
                table: "UserRounds",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRounds_UserId",
                table: "UserRounds",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRounds");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CVs");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
