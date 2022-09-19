using Registration.Model.Enumerations;
using Registration.WebApi.Models.Update.Core;
using System.ComponentModel.DataAnnotations;

namespace Registration.WebApi.Models.Update
{
    public class AddressUpdateModel : BaseUpdateModel
    {
        public string? AddressName { get; set; }

        public string? ZipCode { get; set; }

        public string? City { get; set; }

        [Required(ErrorMessage = "UF é obrigatório")]
        [EnumDataType(typeof(UF))]
        public UF? UF { get; set; }

        public string? District { get; set; }

        public string? Number { get; set; }

        public string? Complement { get; set; }

    }
}