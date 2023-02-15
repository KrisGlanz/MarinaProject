using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarinaProject.Migrations
{
    /// <inheritdoc />
    public partial class Subclasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Boats");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Leases",
                type: "decimal(38,17)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Leases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "balanceDue",
                table: "Leases",
                type: "decimal",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "monthlyPay",
                table: "Leases",
                type: "decimal",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "phoneNum",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(10)");

            migrationBuilder.AlterColumn<int>(
                name: "Registration",
                table: "Boats",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(10)");

            migrationBuilder.AlterColumn<int>(
                name: "BoatType",
                table: "Boats",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(10)");

            migrationBuilder.AlterColumn<int>(
                name: "BoatLength",
                table: "Boats",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(10)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Boats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FuelType",
                table: "Boats",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KneelDepth",
                table: "Boats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Motor",
                table: "Boats",
                type: "varchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotorType",
                table: "Boats",
                type: "varchar(35)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfEngines",
                table: "Boats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRowers",
                table: "Boats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSails",
                table: "Boats",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "balanceDue",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "monthlyPay",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Boats");

            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "Boats");

            migrationBuilder.DropColumn(
                name: "KneelDepth",
                table: "Boats");

            migrationBuilder.DropColumn(
                name: "Motor",
                table: "Boats");

            migrationBuilder.DropColumn(
                name: "MotorType",
                table: "Boats");

            migrationBuilder.DropColumn(
                name: "NumberOfEngines",
                table: "Boats");

            migrationBuilder.DropColumn(
                name: "NumberOfRowers",
                table: "Boats");

            migrationBuilder.DropColumn(
                name: "NumberOfSails",
                table: "Boats");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "Leases",
                type: "double",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,17)");

            migrationBuilder.AlterColumn<int>(
                name: "phoneNum",
                table: "Customers",
                type: "int(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Registration",
                table: "Boats",
                type: "int(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BoatType",
                table: "Boats",
                type: "int(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BoatLength",
                table: "Boats",
                type: "int(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Boats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
