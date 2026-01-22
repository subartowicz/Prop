using AutoMapper;
using Prop.Api.Domain;
using Prop.Api.DTO;

namespace Prop.Api.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Client, ClientDto>();
        CreateMap<Address, AddressDto>();
        CreateMap<Quote, QuoteDto>();
    }
}