using AdventureWorksAPI.Models;
using AdventureWorksAPI.Services;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;

public class Mutation
{
    public async Task<Person> AddPerson(PersonDto input, [Service] IDbContextFactory<AdventureWorksContext> dbFactory)
    {
        var context = dbFactory.CreateDbContext();

        var person = new Person
        {
            PersonType = input.PersonType,
            Title = input.Title,
            FirstName = input.FirstName,
            MiddleName = input.MiddleName,
            LastName = input.LastName,
            Suffix = input.Suffix,
            EmailPromotion = input.EmailPromotion,
            IsActive = true
        };

        context.DbSetOfPersons.Add(person);
        await context.SaveChangesAsync();

        return person;
    }
}
