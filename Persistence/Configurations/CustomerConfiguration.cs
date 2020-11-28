using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasOne(e => e.Gender).WithMany(r => r.Customers).HasForeignKey(e => e.GenderId);
            builder.HasOne(e => e.City).WithMany(r => r.Customers).HasForeignKey(e => e.CityId);
            builder.HasOne(e => e.Region).WithMany(r => r.Customers).HasForeignKey(e => e.RegionId);
            builder.HasOne(e => e.Classification).WithMany(r => r.Customers).HasForeignKey(e => e.ClassificationId);
            builder.HasOne(e => e.User).WithMany(r => r.Customers).HasForeignKey(e => e.UserId);

        }
    }
}