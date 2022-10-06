using Registration.WebApi.Models.Update.Core;

namespace Registration.WebApi.Models.Update.Provider
{
    public class ProviderUpdateModel : BaseUpdateModel
    {
        public string? Name { get; set; }

        public string? RegistrationNumber { get; set; }

        public AddressUpdateModel? Address { get; set; }
    }
}
