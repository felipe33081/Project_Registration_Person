using Registration.Model.Enumerations;
using Registration.Model;
using Registration.WebApi.Models.Read.Core;
using System.ComponentModel.DataAnnotations;

namespace Registration.WebApi.Models.Read.Account
{
    public class PersonReadModel : BaseReadModel
    {
        public string? Name { get; set; }

        [Required]
        public string? RegistrationNumber { get; set; }

        public Address? Address { get; set; }

        [Required]
        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Phone2 { get; set; }

        public string? Nationality { get; set; }

        public DateTimeOffset? BirthDate { get; set; }

        [EnumDataType(typeof(CivilStatus))]
        public CivilStatus? CivilStatus { get; set; }

        [EnumDataType(typeof(Gender))]
        public Gender? Gender { get; set; }

        [EnumDataType(typeof(DocumentType))]
        public DocumentType? DocumentType { get; set; }

        public string? DocumentNumber { get; set; }

        public string? DocumentIssuer { get; set; }

        public DateTimeOffset? DocumentIssuanceDate { get; set; }

        public DateTimeOffset? DocumentExpiration { get; set; }

        public string? MothersName { get; set; }

        public string? FathersName { get; set; }

        public string? PlaceOfBirthCountry { get; set; }

        public string? PlaceOfBirthState { get; set; }

        [EnumDataType(typeof(ResidenceType))]
        public ResidenceType? ResidenceType { get; set; }

        public string? Workplace { get; set; }

        public string? Occupation { get; set; }

        [EnumDataType(typeof(OccupationType))]
        public OccupationType? OccupationType { get; set; }

        public decimal? NetSalary { get; set; }
    }
}
