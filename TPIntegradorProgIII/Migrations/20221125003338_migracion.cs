using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPIntegradorProgIII.Migrations
{
    public partial class migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MeetName = table.Column<string>(type: "TEXT", nullable: false),
                    MeetDate = table.Column<string>(type: "TEXT", nullable: false),
                    MeetPlace = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Distance = table.Column<int>(type: "INTEGER", nullable: false),
                    Style = table.Column<string>(type: "TEXT", nullable: false),
                    MeetName = table.Column<string>(type: "TEXT", nullable: false),
                    MeetId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trials_Meets_MeetId",
                        column: x => x.MeetId,
                        principalTable: "Meets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Swimmers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    DNI = table.Column<int>(type: "INTEGER", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    AttendedTrial = table.Column<string>(type: "TEXT", nullable: false),
                    TrialId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Swimmers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Swimmers_Trials_TrialId",
                        column: x => x.TrialId,
                        principalTable: "Trials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Meets",
                columns: new[] { "Id", "MeetDate", "MeetName", "MeetPlace" },
                values: new object[] { 1, "20-12-2022", "Primer Meet", "Rosario" });

            migrationBuilder.InsertData(
                table: "Meets",
                columns: new[] { "Id", "MeetDate", "MeetName", "MeetPlace" },
                values: new object[] { 2, "25-12-2022", "Segundo Meet", "Buenos Aires" });

            migrationBuilder.InsertData(
                table: "Trials",
                columns: new[] { "Id", "Distance", "MeetId", "MeetName", "Style" },
                values: new object[] { 1, 100, 1, "Primer Meet", "Croll" });

            migrationBuilder.InsertData(
                table: "Trials",
                columns: new[] { "Id", "Distance", "MeetId", "MeetName", "Style" },
                values: new object[] { 2, 150, 2, "Segundo Meet", "Espalda" });

            migrationBuilder.InsertData(
                table: "Swimmers",
                columns: new[] { "Id", "AttendedTrial", "DNI", "Email", "Name", "Password", "Surname", "TrialId", "UserName" },
                values: new object[] { 1, "Croll 100 metros (Primer Meet)", 44555666, "manuel@gmail.com", "Manuel", "2757cb3cafc39af451abb2697be79b4ab61d63d74d85b0418629de8c26811b529f3f3780d0150063ff55a2beee74c4ec102a2a2731a1f1f7f10d473ad18a6a87", "Ibarbia", 1, "string" });

            migrationBuilder.InsertData(
                table: "Swimmers",
                columns: new[] { "Id", "AttendedTrial", "DNI", "Email", "Name", "Password", "Surname", "TrialId", "UserName" },
                values: new object[] { 2, "Croll 100 metros (Primer Meet)", 33444555, "luciano@gmail.com", "Luciano", "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", "Solari", 1, "lucianoS" });

            migrationBuilder.InsertData(
                table: "Swimmers",
                columns: new[] { "Id", "AttendedTrial", "DNI", "Email", "Name", "Password", "Surname", "TrialId", "UserName" },
                values: new object[] { 3, "Espalda 150 metros (Segundo Meet)", 55666777, "santiago@gmail.com", "Santiago", "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413", "Caso", 2, "santiagoC" });

            migrationBuilder.CreateIndex(
                name: "IX_Swimmers_TrialId",
                table: "Swimmers",
                column: "TrialId");

            migrationBuilder.CreateIndex(
                name: "IX_Trials_MeetId",
                table: "Trials",
                column: "MeetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Swimmers");

            migrationBuilder.DropTable(
                name: "Trials");

            migrationBuilder.DropTable(
                name: "Meets");
        }
    }
}
