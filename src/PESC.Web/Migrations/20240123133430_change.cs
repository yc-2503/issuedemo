using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PESC.Web.Migrations
{
    /// <inheritdoc />
    public partial class change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "SCRM_USER_MSCD",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 23, 21, 34, 30, 562, DateTimeKind.Local).AddTicks(2567),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 23, 21, 21, 0, 536, DateTimeKind.Local).AddTicks(81));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastLoginTime",
                table: "SCRM_USER_MSCD",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 23, 21, 34, 30, 562, DateTimeKind.Local).AddTicks(2821),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 23, 21, 21, 0, 536, DateTimeKind.Local).AddTicks(305));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "SCRM_USER_MSCD",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 23, 21, 34, 30, 562, DateTimeKind.Local).AddTicks(2252),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 23, 21, 21, 0, 535, DateTimeKind.Local).AddTicks(9720));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "SCRM_ROLE_MSCD",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "SCRM_ROLE_MSCD",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "SCRM_USER_MSCD",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 23, 21, 21, 0, 536, DateTimeKind.Local).AddTicks(81),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 23, 21, 34, 30, 562, DateTimeKind.Local).AddTicks(2567));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastLoginTime",
                table: "SCRM_USER_MSCD",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 23, 21, 21, 0, 536, DateTimeKind.Local).AddTicks(305),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 1, 23, 21, 34, 30, 562, DateTimeKind.Local).AddTicks(2821));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "SCRM_USER_MSCD",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 23, 21, 21, 0, 535, DateTimeKind.Local).AddTicks(9720),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 1, 23, 21, 34, 30, 562, DateTimeKind.Local).AddTicks(2252));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "SCRM_ROLE_MSCD",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "SCRM_ROLE_MSCD",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
