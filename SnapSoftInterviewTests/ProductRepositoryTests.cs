using SnapSoftInterview.Model;
using SnapSoftInterview.Repository;

namespace SnapSoftInterviewTests;

public class ProductRepositoryTests
{
    private static readonly IProductRepository _productRepository = new ProductRepository();

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 24, 12, 8, 6 })]
    [InlineData(new int[] { 1, 2, 0, 4 }, new int[] { 0, 0, 0, 0 })]
    [InlineData(new int[] { 1, -2, 3, -4 }, new int[] { 24, -12, 8, -6 })]
    [InlineData(new int[] { int.MinValue / 2, 2, 2 }, new int[] { 4, int.MinValue, int.MinValue })]
    public async Task CalculateAHappyPath(int[] input, int[] expectedOutput)
    {
        var product = new Product() { Input = input };
        await _productRepository.CalculateAAsync(product);

        Assert.Equal(expectedOutput, product.Output);
    }

    [Fact]
    public async Task CalculateAExceptionalScenario()
    {
        var input = new Product
        {
            Input = new int[] { int.MaxValue, 2, 3 }
        };

        await Assert.ThrowsAsync<OverflowException>(() => _productRepository.CalculateAAsync(input));
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 24, 12, 8, 6 })]
    [InlineData(new int[] { 1, 2, 0, 4 }, new int[] { 0, 0, 0, 0 })]
    [InlineData(new int[] { 1, -2, 3, -4 }, new int[] { 24, -12, 8, -6 })]
    [InlineData(new int[] { int.MinValue / 2, 2, 2 }, new int[] { 4, int.MinValue, int.MinValue })]
    public async Task CalculateBHappyPath(int[] input, int[] expectedOutput)
    {
        var product = new Product() { Input = input };
        await _productRepository.CalculateBAsync(product);

        Assert.Equal(expectedOutput, product.Output);
    }

    [Fact]
    public async Task CalculateBExceptionalScenario()
    {
        var input = new Product
        {
            Input = new int[] { int.MaxValue, 2, 3 }
        };

        await Assert.ThrowsAsync<OverflowException>(() => _productRepository.CalculateBAsync(input));
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 24, 12, 8, 6 })]
    [InlineData(new int[] { 1, 2, 0, 4 }, new int[] { 0, 0, 0, 0 })]
    [InlineData(new int[] { 1, -2, 3, -4 }, new int[] { 24, -12, 8, -6 })]
    [InlineData(new int[] { int.MinValue / 2, 2, 2 }, new int[] { 4, int.MinValue, int.MinValue })]
    public async Task CalculateCHappyPath(int[] input, int[] expectedOutput)
    {
        var product = new Product() { Input = input };
        await _productRepository.CalculateCAsync(product);

        Assert.Equal(expectedOutput, product.Output);
    }

    [Fact]
    public async Task CalculateCExceptionalScenario()
    {
        var input = new Product
        {
            Input = new int[] { int.MaxValue, 2, 3 }
        };

        await Assert.ThrowsAsync<OverflowException>(() => _productRepository.CalculateCAsync(input));
    }
}
