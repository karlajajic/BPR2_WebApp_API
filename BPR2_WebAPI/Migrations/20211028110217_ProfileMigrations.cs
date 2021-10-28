using Microsoft.EntityFrameworkCore.Migrations;

namespace BPR2_WebAPI.Migrations
{
    public partial class ProfileMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "wishlists");

            migrationBuilder.AddColumn<long>(
                name: "ProfileId",
                table: "wishlists",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateTable(
                name: "credentials",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<long>(type: "bigint", nullable: false),
                    IsEmployee = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_credentials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "customer_profiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<long>(type: "bigint", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_profiles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "credentials");

            migrationBuilder.DropTable(
                name: "customer_profiles");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "wishlists");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "wishlists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "products",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
