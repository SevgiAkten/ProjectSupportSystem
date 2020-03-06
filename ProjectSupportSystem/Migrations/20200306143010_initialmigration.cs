using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSupportSystem.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CategoryName = table.Column<string>(nullable: true),
                    IsPublicSupport = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SupportElements",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SupportElementName = table.Column<string>(nullable: true),
                    SupportElementPercentage = table.Column<int>(nullable: false),
                    SupportElementAmount = table.Column<decimal>(nullable: false),
                    SupPropSupElemID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportElements", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SupportProperties",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SupportName = table.Column<string>(nullable: true),
                    WhoApply = table.Column<string>(nullable: true),
                    Goal = table.Column<string>(nullable: true),
                    ApplicationProcessAndCondition = table.Column<string>(nullable: true),
                    SupportDuration = table.Column<int>(nullable: false),
                    SupportPercentage = table.Column<int>(nullable: false),
                    SupportAmount = table.Column<decimal>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    SupPropSupElemID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportProperties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Supports",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SupportPropertyID = table.Column<Guid>(nullable: false),
                    CategoryID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supports", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Supports_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supports_SupportProperties_SupportPropertyID",
                        column: x => x.SupportPropertyID,
                        principalTable: "SupportProperties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupPropSupElems",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SupportPropertyID = table.Column<Guid>(nullable: false),
                    SupportElementID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupPropSupElems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SupPropSupElems_SupportElements_SupportElementID",
                        column: x => x.SupportElementID,
                        principalTable: "SupportElements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupPropSupElems_SupportProperties_SupportPropertyID",
                        column: x => x.SupportPropertyID,
                        principalTable: "SupportProperties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Supports_CategoryID",
                table: "Supports",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Supports_SupportPropertyID",
                table: "Supports",
                column: "SupportPropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_SupPropSupElems_SupportElementID",
                table: "SupPropSupElems",
                column: "SupportElementID");

            migrationBuilder.CreateIndex(
                name: "IX_SupPropSupElems_SupportPropertyID",
                table: "SupPropSupElems",
                column: "SupportPropertyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Supports");

            migrationBuilder.DropTable(
                name: "SupPropSupElems");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "SupportElements");

            migrationBuilder.DropTable(
                name: "SupportProperties");
        }
    }
}
