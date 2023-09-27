namespace VatoSystems.Data
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using VatoSystems.Data.Common;

    public class DbQueryRunner : IDbQueryRunner
    {
        public DbQueryRunner(VatoDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public VatoDbContext Context { get; set; }

        public Task RunQueryAsync(string query, params object[] parameters)
        {
            return this.Context.Database.ExecuteSqlRawAsync(query, parameters);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Context?.Dispose();
            }
        }
    }
}
