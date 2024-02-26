using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MicroRabbit.Transfer.Data.Context
{
    //this whole file had to be made otherwise the migrations wouldn't be made
    public class TransferDbContextFactory : IDesignTimeDbContextFactory<TransferDbContext>
    {
        public TransferDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TransferDbContext>();
            // Replace with your actual connection string
            //I had to add the actual string not the database to be created in appsetting.json
            optionsBuilder.UseSqlServer("Server=localhost;Database=TransferDb;Trusted_Connection=True;TrustServerCertificate=True;");

            return new TransferDbContext(optionsBuilder.Options);
        }
    }
}
