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

    [UseFiltering]
    [UseSorting]
    public IQueryable<Person> FindPersons(
       string keyword,
       [Service] IDbContextFactory<AdventureWorksContext> dbFactory)
    {
        var context = dbFactory.CreateDbContext();
        return context.DbSetOfPersons.Where(person =>
            EF.Functions.Like(person.FirstName!, $"%{keyword}%") ||
            EF.Functions.Like(person.LastName!, $"%{keyword}%") ||
            EF.Functions.Like(person.PersonType!, $"%{keyword}%") ||
            EF.Functions.Like(person.Title!, $"%{keyword}%") ||
            EF.Functions.Like(person.MiddleName!, $"%{keyword}%") ||
            EF.Functions.Like(person.Suffix!, $"%{keyword}%")
        );
    }
}