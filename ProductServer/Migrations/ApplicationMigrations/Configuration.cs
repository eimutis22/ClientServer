namespace ProductServer.Migrations.ApplicationMigrations
{
    using ProductServer.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductServer.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ApplicationMigrations";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            Seed_Users(context);
        }

        private void Seed_Users(ApplicationDbContext c)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            
            c.Users.AddOrUpdate(
              p => p.Id,
              new ApplicationUser { UserName = "fflyntstone", Email= "flintstone.fred@itsligo.ie", PasswordHash= "Flint$12345" }
            );

        }
    }
}
