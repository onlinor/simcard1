using Microsoft.EntityFrameworkCore.Migrations;

namespace simcard.api.Migrations
{
    public partial class TestModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Shop (Name) VALUES ('Shop1')");
            migrationBuilder.Sql("INSERT INTO Shop (Name) VALUES ('Shop2')");

            migrationBuilder.Sql("INSERT INTO Product (ShopId, Name) VALUES ((Select Id from Shop where Name = 'Shop1'), 'Product A')");
            migrationBuilder.Sql("INSERT INTO Product (ShopId, Name) VALUES ((Select Id from Shop where Name = 'Shop2'), 'Product B')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Shop WHERE Name IN ('Shop1', 'Shop2')");
        }
    }
}
