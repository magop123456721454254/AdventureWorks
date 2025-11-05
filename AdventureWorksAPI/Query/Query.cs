using AdventureWorksAPI.Models;   // your Person entity
using HotChocolate;                // [ScopedService]
using HotChocolate.Data;           // [UseDbContext], projections, filtering
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;

public class Query
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Person> GetPersonsEndpoint(
        [Service] IDbContextFactory<AdventureWorksContext> dbFactory)
    {
        var context = dbFactory.CreateDbContext();
        return context.DbSetOfPersons;
    }
}