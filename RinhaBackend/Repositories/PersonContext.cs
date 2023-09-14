using Microsoft.EntityFrameworkCore;
using RinhaBackend.Models;

namespace RinhaBackend.Repositories;

public class PersonContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=rinha;User Id=rinha;Password=rinha;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
        .Property(p => p.SearchText)
        .HasComputedColumnSql("(lower(\"Person\".\"Surname\" || \"Person\".\"Name\" || \"Person\".\"Stacks\"))", stored: true);
    }
    public DbSet<Person> Person { get; set; }


}