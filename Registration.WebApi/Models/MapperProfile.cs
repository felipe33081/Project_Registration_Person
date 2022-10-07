using AutoMapper;
using Registration.Model;
using Registration.Model.Account;
using Registration.Model.Core;
using Registration.Model.Provider;
using Registration.WebApi.Common;
using Registration.WebApi.Models.Create;
using Registration.WebApi.Models.Create.Account;
using Registration.WebApi.Models.Create.Core;
using Registration.WebApi.Models.Create.Provider;
using Registration.WebApi.Models.Read;
using Registration.WebApi.Models.Read.Account;
using Registration.WebApi.Models.Read.Core;
using Registration.WebApi.Models.Read.Provider;
using Registration.WebApi.Models.Update;
using Registration.WebApi.Models.Update.Account;
using Registration.WebApi.Models.Update.Core;
using Registration.WebApi.Models.Update.Provider;

public class MapperProfile : Profile
{
    public MapperProfile()
    {        
        CreateMap<BaseCreateModel, BaseModel>()
            .AddTransform<string>(s => string.IsNullOrWhiteSpace(s) ? null : s.Trim());

        CreateMap<BaseUpdateModel, BaseModel>()                      
            .AddTransform<string>(s => string.IsNullOrWhiteSpace(s) ? null : s.Trim());

        CreateMap<BaseModel, BaseReadModel>();

        CreateMap<ProductCreateModel, Product>();
        CreateMap<ProductUpdateModel, Product>();
        CreateMap<Product, ProductReadModel>()
            .IncludeBase<BaseModel, BaseReadModel>();

        CreateMap<ProviderCreateModel, Provider>();
        CreateMap<ProviderUpdateModel, Provider>();
        CreateMap<Provider, ProviderReadModel>()
            .IncludeBase<BaseModel, BaseReadModel>();

        CreateMap<Address, AddressUpdateModel>();
        CreateMap<Address, AddressReadModel>()
            .ForMember(dst => dst.UFDisplay,
                map => map.MapFrom(src => RandomHelpers.GetEnumDescription(src.UF)));
        CreateMap<AddressCreateModel, AddressUpdateModel>();
        CreateMap<AddressCreateModel, Address>()
           .IncludeBase<BaseCreateModel, BaseModel>();
        CreateMap<AddressReadModel, Address>();
        CreateMap<AddressUpdateModel, Address>()
            .IncludeBase<BaseUpdateModel, BaseModel>();
    }
}