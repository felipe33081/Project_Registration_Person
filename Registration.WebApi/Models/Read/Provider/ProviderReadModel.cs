using Registration.WebApi.Models.Read.Core;

namespace Registration.WebApi.Models.Read.Provider
{
    public class ProviderReadModel : BaseReadModel
    {
        public string? Name { get; set; }

        public string? RegistrationNumber { get; set; }

        public AddressReadModel? Address { get; set; }
    }
}
