using System.ComponentModel.DataAnnotations;

namespace AdventureWorksAPI.Models
{
    public class PersonDto
    {
        [StringLength(2)]
        public string? PersonType { get; set; }
        
        [StringLength(50)]
        public string? Title { get; set; }
        
        [StringLength(50)]
        public string? FirstName { get; set; }
        
        [StringLength(50)]
        public string? MiddleName { get; set; }
        
        [StringLength(50)]
        public string? LastName { get; set; }
        
        [StringLength(50)]
        public string? Suffix { get; set; }

        public int? EmailPromotion { get; set; }

        public bool? IsActive { get; set; }
    }
}
