using CleanArchtectureMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchtectureMVC.Infra.Data.EntitiesConfiguration{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Price).HasPrecision(10,2);
            builder.HasOne(e=>e.Category).WithMany(e => e.Products).HasForeignKey(e => e.CategoryId);

            builder.HasData(new Product(1, "Test Product", "Test Description Product", 10, 100, "", 1));
        }
    }
}