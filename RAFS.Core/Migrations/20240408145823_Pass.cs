using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAFS.Core.Migrations
{
    /// <inheritdoc />
    public partial class Pass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UserFunctionFarms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 217, DateTimeKind.Utc).AddTicks(4825),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 508, DateTimeKind.Utc).AddTicks(5705));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "TakeAndSendMaterials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 217, DateTimeKind.Utc).AddTicks(2603),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 508, DateTimeKind.Utc).AddTicks(3815));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendDate",
                table: "QuestionForms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 217, DateTimeKind.Utc).AddTicks(1671),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 508, DateTimeKind.Utc).AddTicks(2957));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Plants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 217, DateTimeKind.Utc).AddTicks(578),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 508, DateTimeKind.Utc).AddTicks(1907));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Milestones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(9179),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 508, DateTimeKind.Utc).AddTicks(557));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(7558),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 507, DateTimeKind.Utc).AddTicks(9074));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(7126),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 507, DateTimeKind.Utc).AddTicks(8679));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Farms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(5638),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 507, DateTimeKind.Utc).AddTicks(7440));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EstablishedDate",
                table: "Farms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(4943),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 507, DateTimeKind.Utc).AddTicks(6877));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Farms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(5258),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 507, DateTimeKind.Utc).AddTicks(7115));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Diaries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(3664),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 507, DateTimeKind.Utc).AddTicks(4503));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDay",
                table: "Diaries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(3198),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 507, DateTimeKind.Utc).AddTicks(4105));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "CashFlows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(1465),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 507, DateTimeKind.Utc).AddTicks(2504));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 215, DateTimeKind.Utc).AddTicks(8893),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 507, DateTimeKind.Utc).AddTicks(330));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 215, DateTimeKind.Utc).AddTicks(8604),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 506, DateTimeKind.Utc).AddTicks(9912));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 215, DateTimeKind.Utc).AddTicks(7586),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 506, DateTimeKind.Utc).AddTicks(8787));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UserFunctionFarms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 508, DateTimeKind.Utc).AddTicks(5705),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 217, DateTimeKind.Utc).AddTicks(4825));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "TakeAndSendMaterials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 508, DateTimeKind.Utc).AddTicks(3815),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 217, DateTimeKind.Utc).AddTicks(2603));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendDate",
                table: "QuestionForms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 508, DateTimeKind.Utc).AddTicks(2957),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 217, DateTimeKind.Utc).AddTicks(1671));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Plants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 508, DateTimeKind.Utc).AddTicks(1907),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 217, DateTimeKind.Utc).AddTicks(578));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Milestones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 508, DateTimeKind.Utc).AddTicks(557),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(9179));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 507, DateTimeKind.Utc).AddTicks(9074),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(7558));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 507, DateTimeKind.Utc).AddTicks(8679),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(7126));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Farms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 507, DateTimeKind.Utc).AddTicks(7440),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(5638));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EstablishedDate",
                table: "Farms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 507, DateTimeKind.Utc).AddTicks(6877),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(4943));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Farms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 507, DateTimeKind.Utc).AddTicks(7115),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(5258));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Diaries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 507, DateTimeKind.Utc).AddTicks(4503),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(3664));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDay",
                table: "Diaries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 507, DateTimeKind.Utc).AddTicks(4105),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(3198));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "CashFlows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 507, DateTimeKind.Utc).AddTicks(2504),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 216, DateTimeKind.Utc).AddTicks(1465));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 507, DateTimeKind.Utc).AddTicks(330),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 215, DateTimeKind.Utc).AddTicks(8893));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 506, DateTimeKind.Utc).AddTicks(9912),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 215, DateTimeKind.Utc).AddTicks(8604));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 506, DateTimeKind.Utc).AddTicks(8787),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 8, 14, 58, 22, 215, DateTimeKind.Utc).AddTicks(7586));

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 7, 16, 57, 53, 507, DateTimeKind.Utc).AddTicks(5511)),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Username = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_FarmId",
                table: "Employees",
                column: "FarmId");
        }
    }
}
