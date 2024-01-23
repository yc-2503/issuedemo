using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PESC.Web.Migrations
{
    /// <inheritdoc />
    public partial class _01162 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SCRM_ROLE_DFNT",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCRM_ROLE_DFNT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SCRM_USER_DFNT",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Factory = table.Column<string>(type: "text", nullable: false),
                    LoginId = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Desc = table.Column<string>(type: "text", nullable: true),
                    FailCnt = table.Column<int>(type: "integer", nullable: false),
                    DepartmentId = table.Column<string>(type: "text", nullable: true),
                    Mail = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastLoginTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCRM_USER_DFNT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SCRM_USER_ROLE",
                columns: table => new
                {
                    RolesId = table.Column<long>(type: "bigint", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCRM_USER_ROLE", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_SCRM_USER_ROLE_SCRM_ROLE_DFNT_RolesId",
                        column: x => x.RolesId,
                        principalTable: "SCRM_ROLE_DFNT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SCRM_USER_ROLE_SCRM_USER_DFNT_UsersId",
                        column: x => x.UsersId,
                        principalTable: "SCRM_USER_DFNT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SCRM_USER_ROLE_UsersId",
                table: "SCRM_USER_ROLE",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SCRM_USER_ROLE");

            migrationBuilder.DropTable(
                name: "SCRM_ROLE_DFNT");

            migrationBuilder.DropTable(
                name: "SCRM_USER_DFNT");
        }
    }
}
