using SnapSoftInterview.Model;

namespace SnapSoftInterview.Repository;

public interface IProductRepository
{
    Task CalculateAAsync(Product input);

    Task CalculateBAsync(Product input);

    Task CalculateCAsync(Product input);
}

