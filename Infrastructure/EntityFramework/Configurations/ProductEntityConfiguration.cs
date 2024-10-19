using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Raffle.Domain.Entities.Product;

namespace Raffle.Infrastructure.EntityFramework.Configurations
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnName("Description")
                .HasMaxLength(200);

            builder.Property(x => x.ClientId)
                .HasColumnName("ClientId")
                .IsRequired();

            builder.Property(x => x.CreationDateTime)
                .HasColumnName("CreationDateTime")
                .IsRequired();

            builder.Property(x => x.UpdateDateTime)
                .HasColumnName("UpdateDateTime");

            builder.HasMany(x => x.AssignedNumbers)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
