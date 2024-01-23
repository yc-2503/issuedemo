using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PESC.Web.Migrations
{
    /// <inheritdoc />
    public partial class changerole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "SCRM_USER_MSCD",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 23, 21, 38, 18, 199, DateTimeKind.Local).AddTicks(503),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 23, 21, 34, 30, 562, DateTimeKind.Local).AddTicks(2567));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastLoginTime",
                table: "SCRM_USER_MSCD",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 23, 21, 38, 18, 199, DateTimeKind.Local).AddTicks(729),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 1, 23, 21, 34, 30, 562, DateTimeKind.Local).AddTicks(2821));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "SCRM_USER_MSCD",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 23, 21, 38, 18, 199, DateTimeKind.Local).AddTicks(183),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 1, 23, 21, 34, 30, 562, DateTimeKind.Local).AddTicks(2252));

            migrationBuilder.AlterColumn<string>(
                name: "LastModifierId",
                table: "SCRM_ROLE_MSCD",
                type: "text",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "SCRM_ROLE_MSCD",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 23, 21, 38, 18, 200, DateTimeKind.Local).AddTicks(3652),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "SCRM_ROLE_MSCD",
                type: "character varying(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "SCRM_ROLE_MSCD",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 23, 21, 38, 18, 200, DateTimeKind.Local).AddTicks(3359),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "SCRM_USER_MSCD",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 23, 21, 34, 30, 562, DateTimeKind.Local).AddTicks(2567),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 23, 21, 38, 18, 199, DateTimeKind.Local).AddTicks(503));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastLoginTime",
                table: "SCRM_USER_MSCD",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 23, 21, 34, 30, 562, DateTimeKind.Local).AddTicks(2821),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 1, 23, 21, 38, 18, 199, DateTimeKind.Local).AddTicks(729));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "SCRM_USER_MSCD",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 23, 21, 34, 30, 562, DateTimeKind.Local).AddTicks(2252),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 1, 23, 21, 38, 18, 199, DateTimeKind.Local).AddTicks(183));

            migrationBuilder.AlterColumn<long>(
                name: "LastModifierId",
                table: "SCRM_ROLE_MSCD",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "SCRM_ROLE_MSCD",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 23, 21, 38, 18, 200, DateTimeKind.Local).AddTicks(3652));

            migrationBuilder.AlterColumn<long>(
                name: "CreatorId",
                table: "SCRM_ROLE_MSCD",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "SCRM_ROLE_MSCD",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 1, 23, 21, 38, 18, 200, DateTimeKind.Local).AddTicks(3359));
        }
    }
}
