using Microsoft.EntityFrameworkCore;
using Shoper.Entities;

namespace Shoper.Data
{
    public class ShoperContext:DbContext
    {
        public ShoperContext()
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-A6PJE9T\SQLEXPRESS;Database=ShoperDb;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tablo ismi ve tabloya ait primary key verilir.
            modelBuilder.Entity<Category>().ToTable("Category").HasKey(c=>c.CategoryId);
            modelBuilder.Entity<Product>().ToTable("Product").HasKey(p => p.ProductId);
            modelBuilder.Entity<ProductPrice>().ToTable("ProductPrice").HasKey(pp => pp.PriceId);
            modelBuilder.Entity<ProductImage>().ToTable("ProductImage").HasKey(pi => pi.ImageId);
            // Relations
            //category-product
            modelBuilder.Entity<Category>()
                .HasMany<Product>(c=>c.Products)
                .WithOne(p=>p.Product_Category)
                .HasForeignKey(p=>p.CategoryId)
                .HasConstraintName("Fk_ProductCategory")
                .OnDelete(DeleteBehavior.Cascade);
            // productPrice-product
            modelBuilder.Entity<ProductPrice>()
                .HasOne<Product>(pp => pp.ProductPrc)
                .WithMany(p => p.ProductPrice)
                .HasForeignKey(pp => pp.ProductId)
                .HasConstraintName("Fk_ProductPriceToProduct");
            // product-productımage
            modelBuilder.Entity<ProductImage>()
                .HasOne<Product>(pp => pp.ProductImages)
                .WithMany(p => p.ProductImage)
                .HasForeignKey(pp => pp.ProductId)
                .HasConstraintName("Fk_ProductImageToProduct");
                
        }
    }
}