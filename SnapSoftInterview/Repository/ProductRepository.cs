using SnapSoftInterview.Model;

namespace SnapSoftInterview.Repository;

public class ProductRepository : IProductRepository
{
    public async Task<int[]> CalculateAAsync(ProductInput input)
    {
        return await Task.Run(() => input.value);
    }

    public async Task<int[]> CalculateBAsync(ProductInput input)
    {
        return await Task.Run(() => input.value);
    }

    public async Task<int[]> CalculateCAsync(ProductInput input)
    {
        return await Task.Run(() => input.value);
    }
}
