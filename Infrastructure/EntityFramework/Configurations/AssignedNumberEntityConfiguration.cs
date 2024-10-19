using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Raffle.Domain.Entities.AssignedNumber;

namespace Raffle.Infrastructure.EntityFramework.Configurations
{
    public class AssignedNumberEntityConfiguration : IEntityTypeConfiguration<AssignedNumberEntity>
    {
        public void Configure(EntityTypeBuilder<AssignedNumberEntity> builder)
        {
            builder.ToTable("AssignedNumber");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Number)
                .HasColumnName("Number")
                .HasMaxLength(5)
                .IsRequired();

            builder.Property(x => x.UserId)
                .HasColumnName("UserId")
                .IsRequired();

            builder.Property(x => x.ProductId)
                .HasColumnName("ProductId")
                .IsRequired();

            builder.Property(x => x.CreationDateTime)
                .HasColumnName("CreationDateTime")
                .IsRequired();

            builder.Property(x => x.UpdateDateTime)
                .HasColumnName("UpdateDateTime");
        }
    }
}
