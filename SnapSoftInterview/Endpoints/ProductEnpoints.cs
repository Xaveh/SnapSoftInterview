using AutoMapper;
using SnapSoftInterview.Mapping.DTO;
using SnapSoftInterview.Model;
using SnapSoftInterview.Repository;

namespace SnapSoftInterview.Endpoints;

public static class ProductEnpoints
{
    public static void MapProductEnpoints(this WebApplication app)
    {
        app.MapPost("/api/calculate/a", CalculateAAsync);
        app.MapPost("/api/calculate/b", CalculateBAsync);
        app.MapPost("/api/calculate/c", CalculateCAsync);
    }

    internal static async Task<IResult> CalculateAAsync(IProductRepository repository, IMapper mapper, ProductInputDto input)
    {
        try
        {
            var product = mapper.Map<Product>(input);
            await repository.CalculateAAsync(product);
            return product.Output is not null ? Results.Ok(mapper.Map<ProductOutputDto>(product)) : Results.BadRequest();
        }
        catch (Exception e)
        {
            return Results.BadRequest(e.Message);
        }
    }

    internal static async Task<IResult> CalculateBAsync(IProductRepository repository, IMapper mapper, ProductInputDto input)
    {
        try
        {
            var product = mapper.Map<Product>(input);
            await repository.CalculateBAsync(product);
            return product.Output is not null ? Results.Ok(mapper.Map<ProductOutputDto>(product)) : Results.BadRequest();
        }
        catch (Exception e)
        {
            return Results.BadRequest(e.Message);
        }
    }

    internal static async Task<IResult> CalculateCAsync(IProductRepository repository, IMapper mapper, ProductInputDto input)
    {
        try
        {
            var product = mapper.Map<Product>(input);
            await repository.CalculateCAsync(product);
            return product.Output is not null ? Results.Ok(mapper.Map<ProductOutputDto>(product)) : Results.BadRequest();
        }
        catch (Exception e)
        {
            return Results.BadRequest(e.Message);
        }
    }
}
