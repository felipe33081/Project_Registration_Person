using Registration.Model.Core;
using System.ComponentModel.DataAnnotations;

namespace Registration.Model.Provider
{
    public class Provider : BaseModel
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? RegistrationNumber { get; set; }

        public Address? Address { get; set; }
    }
}
