namespace ProductServer.Migrations.ApplicationMigrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
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

        protected override void Seed(ApplicationDbContext c)
        {
            // Seed_Users(c);
            // Create_Role(c);
        }

        private void Create_Role(ApplicationDbContext c)
        {
            var manager =
                 new UserManager<ApplicationUser>(
                     new UserStore<ApplicationUser>(c));

            var roleManager =
                 new RoleManager<IdentityRole>(
                     new RoleStore<IdentityRole>(c));

            roleManager.Create(new IdentityRole { Name = "PurchasesManager" });


            ApplicationUser purchasesManager = manager.FindByEmail("flintstone.fred@itsligo.ie");

            if (purchasesManager != null)
                manager.AddToRoles(purchasesManager.Id, new string[] { "PurchasesManager" });
            else 
                throw new Exception { Source = "Did not find user" };

        }

        private void Seed_Users(ApplicationDbContext c)
        {
            c.Users.AddOrUpdate(
              p => p.Id,
              new ApplicationUser { UserName = "fflyntstone", Email= "flintstone.fred@itsligo.ie", PasswordHash= "Flint$12345" }
            );

        }
    }
}
