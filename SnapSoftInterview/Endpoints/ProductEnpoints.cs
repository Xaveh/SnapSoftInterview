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

    internal static async Task<IResult> CalculateAAsync(IProductRepository repository, ProductInput input)
    {
        try
        {
            var output = await repository.CalculateAAsync(input);
            return output is not null ? Results.Ok(output) : Results.BadRequest();
        }
        catch (Exception e)
        {
            return Results.BadRequest(e.Message);
        }
    }

    internal static async Task<IResult> CalculateBAsync(IProductRepository repository, ProductInput input)
    {
        var output = await repository.CalculateBAsync(input);
        return output is not null ? Results.Ok(output) : Results.BadRequest();
    }

    internal static async Task<IResult> CalculateCAsync(IProductRepository repository, ProductInput input)
    {
        var output = await repository.CalculateCAsync(input);
        return output is not null ? Results.Ok(output) : Results.BadRequest();
    }
}
