using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class CarInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    InsuranceDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    OilChangeDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NextInspectionDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NextInsuranceDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NextOilChangeDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarInfos_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "CarInfos",
                columns: new[] { "Id", "CarId", "InspectionDate", "InsuranceDate", "NextInspectionDate", "NextInsuranceDate", "NextOilChangeDate", "OilChangeDate" },
                values: new object[] { 1, 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_CarInfos_CarId",
                table: "CarInfos",
                column: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarInfos");
        }
    }
}
