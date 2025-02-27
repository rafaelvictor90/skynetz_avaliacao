using Skynetz.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Skynetz.Infra.Data.EntitiesConfiguration
{
    public class FlatRateConfiguration : EntityTypeConfiguration<FlatRate>
    {
        public void Configure()
        {
            HasKey(f => f.Id);
            Property(f => f.Origin).HasMaxLength(100).IsRequired();
            Property(f => f.Destiny).HasMaxLength(100).IsRequired();
            Property(f => f.MinuteValue).HasPrecision(10, 2).IsRequired();
        }
    }
}