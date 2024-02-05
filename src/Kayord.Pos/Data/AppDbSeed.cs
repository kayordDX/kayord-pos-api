using System.Reflection;
using Bogus;
using Bogus.Extensions.UnitedStates;
using Humanizer;
using Kayord.Pos.Common.Enums;
using Kayord.Pos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kayord.Pos.Data;

public static class AppDbSeed
{
    public static async Task SeedData(AppDbContext context, CancellationToken cancellationToken)
    {
        await context.Database.ExecuteSqlRawAsync("""TRUNCATE TABLE "Business" RESTART IDENTITY CASCADE;""");
        if (!context.Business.Any())
        {
            var table = new Faker<Table>()
                .RuleFor(o => o.Name, f => f.Name.JobArea())
                .RuleFor(o => o.Capacity, f => f.Random.Int(1, 14));
            var section = new Faker<Section>()
                .RuleFor(o => o.Name, f => f.Name.FirstName())
                .RuleFor(o => o.Tables, _ => table.GenerateBetween(5, 7));
            var outlet = new Faker<Outlet>()
                .RuleFor(o => o.Name, f => f.Company.CompanyName())
                .RuleFor(o => o.Sections, _ => section.GenerateBetween(3, 5));
            var business = new Faker<Business>()
                .RuleFor(o => o.Name, f => f.Company.CompanyName())
                .RuleFor(o => o.Outlets, _ => outlet.GenerateBetween(2, 5));


            var results = business.GenerateBetween(1, 1);
            await context.Business.AddRangeAsync(results);
            await context.SaveChangesAsync(cancellationToken);
        }

        if (!context.Role.Any())
        {
            await context.Role.AddAsync(new Role { Name = "Guest", Description = "Guest", RoleId = 1 });
            await context.Role.AddAsync(new Role { Name = "Waiter", Description = "Waiter", RoleId = 2 });
            await context.Role.AddAsync(new Role { Name = "Chef", Description = "Chef", RoleId = 3 });
            await context.Role.AddAsync(new Role { Name = "Manager", Description = "Manager", RoleId = 4 });
            await context.SaveChangesAsync(cancellationToken);
        }
        await context.Database.ExecuteSqlRawAsync("""TRUNCATE TABLE "Menu" RESTART IDENTITY CASCADE;""");
        await context.Database.ExecuteSqlRawAsync("""TRUNCATE TABLE "MenuSection" RESTART IDENTITY CASCADE;""");
        await context.Database.ExecuteSqlRawAsync("""TRUNCATE TABLE "MenuItem" RESTART IDENTITY CASCADE;""");


        if (!context.Menu.Any())
        {

            await context.Menu.AddAsync(new Menu { Name = "Jessica's Ruimsig", OutletId = 1 });

            await context.MenuSection.AddAsync(new MenuSection { Name = "Burgers", MenuId = 1 });
            await context.MenuSection.AddAsync(new MenuSection { Name = "Drinks", MenuId = 1 });
            await context.MenuSection.AddAsync(new MenuSection { Name = "Cocktails", MenuId = 1, ParentId = 2 });
            await context.MenuSection.AddAsync(new MenuSection { Name = "Soft Drinks", MenuId = 1, ParentId = 2 });
            await context.MenuSection.AddAsync(new MenuSection { Name = "Hot Beverage", MenuId = 1, ParentId = 2 });
            await context.MenuSection.AddAsync(new MenuSection { Name = "Coffee/Cappucino", MenuId = 1, ParentId = 5 });
            await context.MenuSection.AddAsync(new MenuSection { Name = "Desert", MenuId = 1 });
            await context.MenuSection.AddAsync(new MenuSection { Name = "Pizza", MenuId = 1 });
            await context.SaveChangesAsync(cancellationToken);
            await context.MenuItem.AddAsync(new MenuItem { Name = "Coffee", MenuSectionId = 6, Price = 1 });
            await context.MenuItem.AddAsync(new MenuItem { Name = "Cappucino", MenuSectionId = 6, Price = 1 });
            await context.MenuItem.AddAsync(new MenuItem { Name = "Coke", MenuSectionId = 4, Price = 1 });
            await context.SaveChangesAsync(cancellationToken);


        }

    }
}