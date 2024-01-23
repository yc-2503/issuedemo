using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PESC.Web.Migrations
{
    /// <inheritdoc />
    public partial class changetablenamedefine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SCRM_USER_ROLE_SCRM_ROLE_DFNT_RolesId",
                table: "SCRM_USER_ROLE");

            migrationBuilder.DropForeignKey(
                name: "FK_SCRM_USER_ROLE_SCRM_USER_DFNT_UsersId",
                table: "SCRM_USER_ROLE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SCRM_USER_DFNT",
                table: "SCRM_USER_DFNT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SCRM_ROLE_DFNT",
                table: "SCRM_ROLE_DFNT");

            migrationBuilder.RenameTable(
                name: "SCRM_USER_DFNT",
                newName: "SCRM_USER_MSCD");

            migrationBuilder.RenameTable(
                name: "SCRM_ROLE_DFNT",
                newName: "SCRM_ROLE_MSCD");

            migrationBuilder.AlterColumn<string>(
                name: "Factory",
                table: "SCRM_USER_MSCD",
                type: "character varying(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Factory",
                table: "SCRM_ROLE_MSCD",
                type: "character varying(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SCRM_USER_MSCD",
                table: "SCRM_USER_MSCD",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SCRM_ROLE_MSCD",
                table: "SCRM_ROLE_MSCD",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SCRM_USER_MSCD_Factory_LoginId",
                table: "SCRM_USER_MSCD",
                columns: new[] { "Factory", "LoginId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SCRM_ROLE_MSCD_Factory_RoleName",
                table: "SCRM_ROLE_MSCD",
                columns: new[] { "Factory", "RoleName" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SCRM_USER_ROLE_SCRM_ROLE_MSCD_RolesId",
                table: "SCRM_USER_ROLE",
                column: "RolesId",
                principalTable: "SCRM_ROLE_MSCD",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SCRM_USER_ROLE_SCRM_USER_MSCD_UsersId",
                table: "SCRM_USER_ROLE",
                column: "UsersId",
                principalTable: "SCRM_USER_MSCD",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SCRM_USER_ROLE_SCRM_ROLE_MSCD_RolesId",
                table: "SCRM_USER_ROLE");

            migrationBuilder.DropForeignKey(
                name: "FK_SCRM_USER_ROLE_SCRM_USER_MSCD_UsersId",
                table: "SCRM_USER_ROLE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SCRM_USER_MSCD",
                table: "SCRM_USER_MSCD");

            migrationBuilder.DropIndex(
                name: "IX_SCRM_USER_MSCD_Factory_LoginId",
                table: "SCRM_USER_MSCD");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SCRM_ROLE_MSCD",
                table: "SCRM_ROLE_MSCD");

            migrationBuilder.DropIndex(
                name: "IX_SCRM_ROLE_MSCD_Factory_RoleName",
                table: "SCRM_ROLE_MSCD");

            migrationBuilder.DropColumn(
                name: "Factory",
                table: "SCRM_ROLE_MSCD");

            migrationBuilder.RenameTable(
                name: "SCRM_USER_MSCD",
                newName: "SCRM_USER_DFNT");

            migrationBuilder.RenameTable(
                name: "SCRM_ROLE_MSCD",
                newName: "SCRM_ROLE_DFNT");

            migrationBuilder.AlterColumn<string>(
                name: "Factory",
                table: "SCRM_USER_DFNT",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(32)",
                oldMaxLength: 32);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SCRM_USER_DFNT",
                table: "SCRM_USER_DFNT",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SCRM_ROLE_DFNT",
                table: "SCRM_ROLE_DFNT",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SCRM_USER_ROLE_SCRM_ROLE_DFNT_RolesId",
                table: "SCRM_USER_ROLE",
                column: "RolesId",
                principalTable: "SCRM_ROLE_DFNT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SCRM_USER_ROLE_SCRM_USER_DFNT_UsersId",
                table: "SCRM_USER_ROLE",
                column: "UsersId",
                principalTable: "SCRM_USER_DFNT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
