using Registration.WebApi.Models.Create.Core;
using System.ComponentModel.DataAnnotations;

namespace Registration.WebApi.Models.Create.Provider
{
    public class ProviderCreateModel : BaseCreateModel
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? RegistrationNumber { get; set; }

        public AddressCreateModel? Address { get; set; }
    }
}
