using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata;
using System.Security.Cryptography;

public class AdventureWorksContext(DbContextOptions<AdventureWorksContext> options) : DbContext
{
    public DbSet<Person> DbSetOfPersons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Map the table in the correct schema
        modelBuilder.Entity<Person>()
            .HasKey(p => p.BusinessEntityId);

        modelBuilder.Entity<Person>()
            .ToTable("Person", "Person")
            .HasQueryFilter(p => p.IsActive)
            .ToTable(tb => tb.UseSqlOutputClause(false)); // Table = Person.Person

        base.OnModelCreating(modelBuilder);
    }
}