using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {

        }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Dictionary<int, string> categories = new Dictionary<int, string>
                {
                    { 1, "T-shirt" },
                    { 2, "Shoes" },
                    { 3, "Hat" }
                };

            modelBuilder.Entity<Product>().HasData(
                Enumerable.Range(1, 15).Select(i =>
                {
                    int categoriesIndex = (i - 1) / 5 + 1;

                    return new Product
                    {
                        Id = i,
                        Name = $"Product #{i}",
                        Price = 69.9m,
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.",
                        CategoryName = categories[categoriesIndex],
                        ImageUrl = "https://placehold.co/400x600"
                    };
                }).ToArray()
            );
        }

    }
}
