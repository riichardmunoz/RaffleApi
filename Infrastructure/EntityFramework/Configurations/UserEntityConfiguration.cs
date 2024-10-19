using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Raffle.Domain.Entities.User;

namespace Raffle.Infrastructure.EntityFramework.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.FullName)
                .HasColumnName("FullName")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Phone)
                .HasColumnName("Phone")
                .HasMaxLength(30);

            builder.Property(x => x.Address)
                .HasColumnName("Address")
                .HasMaxLength(200);

            builder.Property(x => x.CreationDateTime)
                .HasColumnName("CreationDateTime")
                .IsRequired();

            builder.Property(x => x.UpdateDateTime)
                .HasColumnName("UpdateDateTime");

            builder.HasMany(x => x.AssignedNumbers)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}
