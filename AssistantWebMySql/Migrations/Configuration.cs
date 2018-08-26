using System.Data.Entity.Migrations;
using AssistantWebMySql.Models;

namespace AssistantWebMySql.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AssistantContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AssistantContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
