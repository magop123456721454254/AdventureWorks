using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;

public class AdventureWorksContext : DbContext
{
    public AdventureWorksContext(DbContextOptions<AdventureWorksContext> options) : base(options) { }

    public DbSet<Person> DbSetOfPersons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Map the table in the correct schema
        modelBuilder.Entity<Person>()
            .HasKey(p => p.BusinessEntityId);

        modelBuilder.Entity<Person>()
            .ToTable("Person", "Person"); // Table = Person.Person

        base.OnModelCreating(modelBuKKKilder);
    }
}