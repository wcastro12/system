namespace ClinicalSystem.Commons.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ClinicalSystem.Common.Context.ClinicalSystemServicesContext>
    {
        public Configuration()
        {

            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ClinicalSystem.Common.Context.ClinicalSystemServicesContext";
        }

        protected override void Seed(ClinicalSystem.Common.Context.ClinicalSystemServicesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
