using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAFS.Core.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UserFunctionFarms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 778, DateTimeKind.Utc).AddTicks(4385),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 217, DateTimeKind.Utc).AddTicks(4825));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "TakeAndSendMaterials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 778, DateTimeKind.Utc).AddTicks(2301),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 217, DateTimeKind.Utc).AddTicks(2603));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendDate",
                table: "QuestionForms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 778, DateTimeKind.Utc).AddTicks(1290),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 217, DateTimeKind.Utc).AddTicks(1671));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Plants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 778, DateTimeKind.Utc).AddTicks(425),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 217, DateTimeKind.Utc).AddTicks(578));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Milestones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 777, DateTimeKind.Utc).AddTicks(9286),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(9179));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 777, DateTimeKind.Utc).AddTicks(7941),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(7558));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 777, DateTimeKind.Utc).AddTicks(7556),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(7126));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Farms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 777, DateTimeKind.Utc).AddTicks(6481),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(5638));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EstablishedDate",
                table: "Farms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 777, DateTimeKind.Utc).AddTicks(5844),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(4943));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Farms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 777, DateTimeKind.Utc).AddTicks(6133),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(5258));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Diaries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 777, DateTimeKind.Utc).AddTicks(4879),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(3664));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDay",
                table: "Diaries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 777, DateTimeKind.Utc).AddTicks(4550),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(3198));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "CashFlows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 777, DateTimeKind.Utc).AddTicks(3174),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(1465));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 777, DateTimeKind.Utc).AddTicks(1286),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 215, DateTimeKind.Utc).AddTicks(8893));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 777, DateTimeKind.Utc).AddTicks(997),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 215, DateTimeKind.Utc).AddTicks(8604));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 777, DateTimeKind.Utc).AddTicks(212),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 215, DateTimeKind.Utc).AddTicks(7586));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UserFunctionFarms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 217, DateTimeKind.Utc).AddTicks(4825),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 778, DateTimeKind.Utc).AddTicks(4385));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "TakeAndSendMaterials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 217, DateTimeKind.Utc).AddTicks(2603),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 778, DateTimeKind.Utc).AddTicks(2301));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendDate",
                table: "QuestionForms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 217, DateTimeKind.Utc).AddTicks(1671),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 778, DateTimeKind.Utc).AddTicks(1290));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Plants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 217, DateTimeKind.Utc).AddTicks(578),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 778, DateTimeKind.Utc).AddTicks(425));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Milestones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(9179),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 777, DateTimeKind.Utc).AddTicks(9286));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(7558),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 777, DateTimeKind.Utc).AddTicks(7941));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(7126),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 777, DateTimeKind.Utc).AddTicks(7556));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Farms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(5638),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 777, DateTimeKind.Utc).AddTicks(6481));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EstablishedDate",
                table: "Farms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(4943),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 777, DateTimeKind.Utc).AddTicks(5844));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Farms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(5258),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 777, DateTimeKind.Utc).AddTicks(6133));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Diaries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(3664),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 777, DateTimeKind.Utc).AddTicks(4879));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDay",
                table: "Diaries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(3198),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 777, DateTimeKind.Utc).AddTicks(4550));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "CashFlows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(1465),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 777, DateTimeKind.Utc).AddTicks(3174));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 215, DateTimeKind.Utc).AddTicks(8893),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 777, DateTimeKind.Utc).AddTicks(1286));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 215, DateTimeKind.Utc).AddTicks(8604),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 777, DateTimeKind.Utc).AddTicks(997));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 215, DateTimeKind.Utc).AddTicks(7586),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 14, 7, 25, 777, DateTimeKind.Utc).AddTicks(212));
        }
    }
}
