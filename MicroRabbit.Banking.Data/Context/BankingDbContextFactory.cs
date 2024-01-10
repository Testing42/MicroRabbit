using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MicroRabbit.Banking.Data.Context
{
    //this whole file had to be made otherwise the migrations wouldn't be made
    public class BankingDbContextFactory : IDesignTimeDbContextFactory<BankingDbContext>
    {
        public BankingDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BankingDbContext>();
            // Replace with your actual connection string
            //I had to add the actual string not the database to be created in appsetting.json
            optionsBuilder.UseSqlServer("Server=localhost;Database=BankingDb;Trusted_Connection=True;TrustServerCertificate=True;");

            return new BankingDbContext(optionsBuilder.Options);
        }
    }
}
