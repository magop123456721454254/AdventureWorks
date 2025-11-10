using AdventureWorksAPI.Models;   // your Person entity
using AdventureWorksAPI.Services;
using HotChocolate;                // [ScopedService]
using HotChocolate.Data;           // [UseDbContext], projections, filtering
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class Query
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Person> GetPersonsEndpoint(
        [Service] PersonService service)
    {
        return service.GetPersonsList();
    }

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Person> GetPersonsList([Service] IPersonService service, int amount)
    {
        return service.GetPersonsList(amount);
    }

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Person?> GetPerson([Service] IPersonService service, int businessIdentityId)
    {
        return service.GetPerson(businessIdentityId);
    }

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Person> FindPersons([Service] IPersonService service, string keyword)
    {
        return service.FindPersons(keyword);
    }

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<RankedItem> GetRankedOccurances([Service] IPersonService service,
        string propertyName, int listLength, bool orderByDesc)
    {
        return service.GetRankedOccurances(propertyName, listLength, orderByDesc);
    }
}