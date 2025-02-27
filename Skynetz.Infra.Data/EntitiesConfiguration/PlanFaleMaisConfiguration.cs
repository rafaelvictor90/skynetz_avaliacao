using Skynetz.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Skynetz.Infra.Data.EntitiesConfiguration
{
    public class PlanFaleMaisConfiguration : EntityTypeConfiguration<PlanFaleMais>
    {
        public void Configure()
        {
            HasKey(f => f.Id);
            Property(f => f.Name).HasMaxLength(100).IsRequired();
            Property(f => f.MinuteTime).IsRequired();
        }
    }
}