using Registration.Model.Core;
using Registration.Model.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace Registration.Model.Account
{
    public class Person : BaseModel
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? TaxNumber { get; set; }

        public Address? Address { get; set; }

        [Required]
        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Nationality { get; set; }

        public DateTimeOffset? BirthDate { get; set; }

        [EnumDataType(typeof(CivilStatus))]
        public CivilStatus? CivilStatus { get; set; }

        [EnumDataType(typeof(Gender))]
        public Gender? Gender { get; set; }

        [EnumDataType(typeof(OccupationType))]
        public OccupationType? OccupationType { get; set; }

        public decimal? NetSalary { get; set; }

        [Required]
        public decimal? LimitCredit { get; set; }
    }
}
