using SnapSoftInterview.Model;

namespace SnapSoftInterview.Repository;

public class ProductRepository : IProductRepository
{
    public async Task<int[]> CalculateAAsync(ProductInput input)
    {
        return await Task.Run(() =>
        {
            if (input.value.Contains(0))
            {
                return Enumerable.Repeat(0, input.value.Length).ToArray();
            }

            int product = 0;
            checked
            {
                product = input.value.Aggregate(1, (actualProduct, next) => actualProduct * next);
            }

            return input.value.Select(x => product / x).ToArray();
        });
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
