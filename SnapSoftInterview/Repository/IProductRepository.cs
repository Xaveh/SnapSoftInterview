using SnapSoftInterview.Model;

namespace SnapSoftInterview.Repository;

public interface IProductRepository
{
    Task<int[]> CalculateAAsync(ProductInput input);

    Task<int[]> CalculateBAsync(ProductInput input);

    Task<int[]> CalculateCAsync(ProductInput input);
}

