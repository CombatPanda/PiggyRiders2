using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSaver.Migrations
{
    public partial class SmartSaver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EMInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spent = table.Column<int>(type: "int", nullable: true),
                    Limit = table.Column<int>(type: "int", nullable: true),
                    uID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ExpensesInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    expensesInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpensesInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SMInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SavedAmount = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserBalance",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    balance = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBalance", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserExpense",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    expenses = table.Column<int>(type: "int", nullable: false),
                    expensesInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExpense", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserIncome",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    income = table.Column<int>(type: "int", nullable: false),
                    incomeInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIncome", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMInfo");

            migrationBuilder.DropTable(
                name: "ExpensesInfo");

            migrationBuilder.DropTable(
                name: "SMInfo");

            migrationBuilder.DropTable(
                name: "UserBalance");

            migrationBuilder.DropTable(
                name: "UserExpense");

            migrationBuilder.DropTable(
                name: "UserIncome");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
