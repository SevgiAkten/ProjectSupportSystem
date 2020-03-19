using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSupportSystem.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SupportElements",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    SupportElementName = table.Column<string>(nullable: true),
                    SupportElementPercentage = table.Column<int>(nullable: true),
                    SupportElementAmount = table.Column<decimal>(nullable: true),
                    SupportSupElementID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportElements", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Supports",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    SupportType = table.Column<string>(nullable: true),
                    SupportName = table.Column<string>(nullable: true),
                    WhoApply = table.Column<string>(nullable: true),
                    Goal = table.Column<string>(nullable: true),
                    ApplicationProcessAndCondition = table.Column<string>(nullable: true),
                    SupportDuration = table.Column<int>(nullable: true),
                    SupportPercentage = table.Column<int>(nullable: true),
                    SupportAmount = table.Column<decimal>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    SupportSupElementID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supports", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SupportSupElements",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    SupportID = table.Column<int>(nullable: false),
                    SupportElementID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportSupElements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SupportSupElements_SupportElements_SupportElementID",
                        column: x => x.SupportElementID,
                        principalTable: "SupportElements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupportSupElements_Supports_SupportID",
                        column: x => x.SupportID,
                        principalTable: "Supports",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupportSupElements_SupportElementID",
                table: "SupportSupElements",
                column: "SupportElementID");

            migrationBuilder.CreateIndex(
                name: "IX_SupportSupElements_SupportID",
                table: "SupportSupElements",
                column: "SupportID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupportSupElements");

            migrationBuilder.DropTable(
                name: "SupportElements");

            migrationBuilder.DropTable(
                name: "Supports");
        }
    }
}
