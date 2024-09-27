using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using tracker.Models;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer("Server = (local)\\sqlexpress ; Database = TransactionDB ; Trusted_Connection = True ; MultipleActiveResultSets = True;TrustServerCertificate=true;");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
