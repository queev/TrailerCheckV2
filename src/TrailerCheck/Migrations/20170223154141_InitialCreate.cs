using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TrailerCheck.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trailer",
                columns: table => new
                {
                    TrailerID = table.Column<int>(maxLength: 7, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ProductGroup = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trailer", x => x.TrailerID);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OwnerID = table.Column<int>(nullable: false),
                    TrailerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Registration_Owner_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Owner",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registration_Trailer_TrailerID",
                        column: x => x.TrailerID,
                        principalTable: "Trailer",
                        principalColumn: "TrailerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registration_OwnerID",
                table: "Registration",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_TrailerID",
                table: "Registration",
                column: "TrailerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "Trailer");
        }
    }
}
