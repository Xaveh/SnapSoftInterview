using Microsoft.EntityFrameworkCore;
using SnapSoftInterview.Model;

namespace SnapSoftInterview.DAL;

public class ProductContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ProductContext() : base()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(@"host=localhost;username=postgres;password=1234;database=SnapsoftInterview");
}
