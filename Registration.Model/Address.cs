using Registration.Model.Core;
using Registration.Model.Enumerations;

namespace Registration.Model
{
    public class Address : BaseModel
    {
        public string? AddressName { get; set; }

        public string? ZipCode { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public UF? UF { get; set; }

        public string? District { get; set; }

        public string? Number { get; set; }

        public string? Complement { get; set; }

    }
}