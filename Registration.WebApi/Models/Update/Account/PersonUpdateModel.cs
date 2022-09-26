using Registration.Model;
using Registration.Model.Enumerations;
using Registration.WebApi.Models.Update.Core;
using System.ComponentModel.DataAnnotations;

namespace Registration.WebApi.Models.Update.Account
{
    public class PersonUpdateModel : BaseUpdateModel
    {
        public string? Name { get; set; }

        public string? TaxNumber { get; set; }

        public Address? Address { get; set; }

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

        public decimal? LimitCredit { get; set; }
    }
}
