using Skynetz.Domain.Entities;
using Skynetz.Infra.Data.EntitiesConfiguration;
using System.Data.Entity;

namespace Skynetz.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext()
            : base("Name=main")
        { 
        }

        public DbSet<FlatRate> flatRates { get; set; }
        public DbSet<PlanFaleMais> planFaleMais { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Configurations.Add(new FlatRateConfiguration());
            builder.Configurations.Add(new PlanFaleMaisConfiguration());
            base.OnModelCreating(builder);
        }
    }
}