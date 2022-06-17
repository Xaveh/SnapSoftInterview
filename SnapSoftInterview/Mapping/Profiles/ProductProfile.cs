using AutoMapper;
using SnapSoftInterview.Model;
using SnapSoftInterview.Mapping.DTO;


namespace SnapSoftInterview.Mapping.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductInputDto, Product>();
        CreateMap<Product, ProductOutputDto>();
    }
}
