namespace Skynetz.Infra.Data.Migrations
{
    using Skynetz.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Skynetz.Infra.Data.Context.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Skynetz.Infra.Data.Context.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            if (!context.flatRates.Any())
            {
                context.flatRates.Add(new FlatRate(1, "011", "016", 1.90m));
                context.flatRates.Add(new FlatRate(2, "016", "011", 2.90m));
                context.flatRates.Add(new FlatRate(3, "011", "017", 1.70m));
                context.flatRates.Add(new FlatRate(4, "017", "011", 2.70m));
                context.flatRates.Add(new FlatRate(5, "011", "018", 0.90m));
                context.flatRates.Add(new FlatRate(6, "018", "011", 1.90m));

                context.SaveChanges();
            }

            if (!context.planFaleMais.Any())
            {
                context.planFaleMais.Add(new PlanFaleMais(1, "FaleMais 30", 30));
                context.planFaleMais.Add(new PlanFaleMais(2, "FaleMais 60", 60));
                context.planFaleMais.Add(new PlanFaleMais(3, "FaleMais 120", 120));
            }
        }
    }
}
