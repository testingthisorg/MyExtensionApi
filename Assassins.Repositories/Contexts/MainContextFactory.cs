using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Assassins.DataAccess.Contexts
{
    public class MainContextFactory : IDesignTimeDbContextFactory<MainContext>
    {
        public MainContext CreateDbContext(string[] args)
        {
            var connString = "Server=(localdb)\\mssqllocaldb;Database=Assassins.App;Trusted_Connection=True;MultipleActiveResultSets=true";
            //  var connString = "Server=tcp:fawa.database.windows.net,1433;Initial Catalog=fawa-dev;Persist Security Info=False;User ID=fawausr;Password=h0eF0L1p!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            var optionsBuilder = new DbContextOptionsBuilder<MainContext>();
            optionsBuilder.UseSqlServer(connString);

            return new MainContext(optionsBuilder.Options);
        }

        private string GetEnvironmentVariable(string name, string errorMessage)
        {
            var connectionStringName = Environment.GetEnvironmentVariable(name);

            if (string.IsNullOrWhiteSpace(connectionStringName))
            {
                throw new Exception(errorMessage);
            }

            return connectionStringName;
        }
    }
}
