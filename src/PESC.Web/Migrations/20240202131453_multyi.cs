using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PESC.Web.Migrations
{
    /// <inheritdoc />
    public partial class multyi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "SCRM_USER_MSCD",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 2, 21, 14, 51, 683, DateTimeKind.Local).AddTicks(2220),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 2, 20, 57, 59, 523, DateTimeKind.Local).AddTicks(1638));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastLoginTime",
                table: "SCRM_USER_MSCD",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 2, 21, 14, 51, 683, DateTimeKind.Local).AddTicks(2471),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 2, 2, 20, 57, 59, 523, DateTimeKind.Local).AddTicks(1898));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "SCRM_USER_MSCD",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 2, 21, 14, 51, 683, DateTimeKind.Local).AddTicks(1844),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 2, 2, 20, 57, 59, 523, DateTimeKind.Local).AddTicks(1283));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "SCRM_ROLE_MSCD",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 2, 21, 14, 51, 684, DateTimeKind.Local).AddTicks(4964),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 2, 20, 57, 59, 524, DateTimeKind.Local).AddTicks(5138));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "SCRM_ROLE_MSCD",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 2, 21, 14, 51, 684, DateTimeKind.Local).AddTicks(4654),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 2, 2, 20, 57, 59, 524, DateTimeKind.Local).AddTicks(4827));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "SCRM_USER_MSCD",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 2, 20, 57, 59, 523, DateTimeKind.Local).AddTicks(1638),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 2, 21, 14, 51, 683, DateTimeKind.Local).AddTicks(2220));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastLoginTime",
                table: "SCRM_USER_MSCD",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 2, 20, 57, 59, 523, DateTimeKind.Local).AddTicks(1898),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 2, 2, 21, 14, 51, 683, DateTimeKind.Local).AddTicks(2471));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "SCRM_USER_MSCD",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 2, 20, 57, 59, 523, DateTimeKind.Local).AddTicks(1283),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 2, 2, 21, 14, 51, 683, DateTimeKind.Local).AddTicks(1844));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "SCRM_ROLE_MSCD",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 2, 20, 57, 59, 524, DateTimeKind.Local).AddTicks(5138),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 2, 21, 14, 51, 684, DateTimeKind.Local).AddTicks(4964));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "SCRM_ROLE_MSCD",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 2, 20, 57, 59, 524, DateTimeKind.Local).AddTicks(4827),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 2, 2, 21, 14, 51, 684, DateTimeKind.Local).AddTicks(4654));
        }
    }
}
