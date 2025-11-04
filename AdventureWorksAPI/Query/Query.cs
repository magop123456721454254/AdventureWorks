using AdventureWorksAPI.Models;   // your Person entity
using HotChocolate;                // [ScopedService]
using HotChocolate.Data;           // [UseDbContext], projections, filtering
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;

public class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Person> GetPersons(
        [Service] IDbContextFactory<AdventureWorksContext> dbFactory)
    {
        var context = dbFactory.CreateDbContext();
        return context.DbSetOfPersons;
    }
}