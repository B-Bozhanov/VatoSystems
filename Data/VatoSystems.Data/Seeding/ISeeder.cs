namespace VatoSystems.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using VatoSystems.Data;

    public interface ISeeder
    {
        Task SeedAsync(VatoDbContext dbContext, IServiceProvider serviceProvider);
    }
}
