using Registration.Model.Enumerations;
using Registration.WebApi.Models.Create.Core;
using System.ComponentModel.DataAnnotations;

namespace Registration.WebApi.Models.Create
{
    public class AddressCreateModel : BaseCreateModel
    {
        public string? AddressName { get; set; }

        public string? ZipCode { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        [EnumDataType(typeof(UF))]
        public UF? UF { get; set; }

        public string? District { get; set; }

        public string? Number { get; set; }

        public string? Complement { get; set; }

    }
}