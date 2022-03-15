using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductMicroservice.Migrations
{
    public partial class ProductMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "Description", "ImageName", "Price", "ProductName", "Rating" },
                values: new object[,]
                {
                    { 1, "Budjet Friendly", "product1.jpg", 5999.0, "Redmi", 5.0 },
                    { 2, "Camera Clarity", "product2.jpg", 3500.0, "Iphone", 3.0 },
                    { 3, "Good Proccessor", "product3.jpg", 6999.0, "Iqoo7", 4.0 },
                    { 4, "Nice Product", "product4.jpg", 4599.0, "samsung", 2.0 },
                    { 5, "Long Life Time", "product5.jpg", 2900.0, "Nokia", 5.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
