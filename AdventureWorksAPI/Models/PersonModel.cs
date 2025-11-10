using System;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksAPI.Models
{
    public class Person
    {
        [Key]
        public int BusinessEntityId { get; set; }
        public string? PersonType { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Suffix { get; set; }
        public int? EmailPromotion { get; set; }
        public bool IsActive { get; set; }

        public bool AnyPropertyContainsKeyword(string keyword)
        {
            return Title != null && Title.Contains(keyword) ||
                FirstName != null && FirstName.Contains(keyword) ||
                MiddleName != null && MiddleName.Contains(keyword) ||
                LastName != null && LastName.Contains(keyword) ||
                Suffix != null && Suffix.Contains(keyword);
        }

    }

    public class RankedItem(string key, int count)
    {
        public string Key { get; set; } = key;
        public int Count { get; set; } = count;
    }
}