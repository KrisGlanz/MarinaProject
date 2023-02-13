using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarinaProject.Migrations
{
    /// <inheritdoc />
    public partial class AddSlip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Motor",
                table: "Boats");

            migrationBuilder.DropColumn(
                name: "NumberOfRowers",
                table: "Boats");

            migrationBuilder.AlterColumn<decimal>(
                name: "monthlyPay",
                table: "Leases",
                type: "decimal(38,17)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "balanceDue",
                table: "Leases",
                type: "decimal(38,17)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Leases",
                type: "decimal(38,17)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)");

            migrationBuilder.CreateTable(
                name: "Slips",
                columns: table => new
                {
                    slipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    width = table.Column<int>(type: "int", nullable: false),
                    slipLength = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slips", x => x.slipId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slips");

            migrationBuilder.AlterColumn<double>(
                name: "monthlyPay",
                table: "Leases",
                type: "double",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,17)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "balanceDue",
                table: "Leases",
                type: "double",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,17)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Leases",
                type: "decimal(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,17)");

            migrationBuilder.AddColumn<string>(
                name: "Motor",
                table: "Boats",
                type: "varchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRowers",
                table: "Boats",
                type: "int",
                nullable: true);
        }
    }
}
