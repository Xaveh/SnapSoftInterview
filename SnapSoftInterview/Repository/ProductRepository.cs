using SnapSoftInterview.Model;

namespace SnapSoftInterview.Repository;

public class ProductRepository : IProductRepository
{
    private static readonly Func<IEnumerable<int>, int> CalculateProduct = (input) => input.Aggregate(1, (actualProduct, next) => checked(actualProduct * next));

    public async Task<int[]> CalculateAAsync(ProductInput input)
    {
        return await Task.Run(() =>
        {
            if (input.value.Contains(0))
            {
                return Enumerable.Repeat(0, input.value.Length).ToArray();
            }

            int product = CalculateProduct(input.value);

            return input.value.Select(x => product / x).ToArray();
        });
    }

    public async Task<int[]> CalculateBAsync(ProductInput input)
    {
        return await Task.Run(() =>
        {
            if (input.value.Contains(0))
            {
                return Enumerable.Repeat(0, input.value.Length).ToArray();
            }

            var result = new int[input.value.Length];
            for (int i = 0; i < input.value.Length; i++)
            {
                result[i] = CalculateProduct(input.value.Select((x, index) => i != index ? x : 1));
            }

            return result;
        });
    }

    public async Task<int[]> CalculateCAsync(ProductInput input)
    {
        return await Task.Run(() =>
        {
            if (input.value.Contains(0))
            {
                return Enumerable.Repeat(0, input.value.Length).ToArray();
            }

            int product = CalculateProduct(input.value);

            return input.value.Select(x => product.CheatDivide(x)).ToArray();
        });
    }
}

internal static class HelperExtensionMethods
{
    internal static int CheatDivide(this int numerator, int denominator)
    {
        ulong numeratorUlong = numerator > 0 ? Convert.ToUInt64(numerator) : Convert.ToUInt64(-numerator);
        ulong denominatorUlong = denominator > 0 ? Convert.ToUInt64(denominator) : Convert.ToUInt64(-denominator);

        ulong result = 0; ulong mask = 1;
        while (numeratorUlong >= denominatorUlong)
        {
            denominatorUlong <<= 1;
            mask <<= 1;
        }

        while ((mask & 1) == 0)
        {
            denominatorUlong >>= 1;
            mask >>= 1;
            if (numeratorUlong >= denominatorUlong)
            {
                result |= mask;
                numeratorUlong -= denominatorUlong;
            };
        };

        if ((numerator > 0 && denominator > 0) || (numerator < 0 && denominator < 0))
        {
            return Convert.ToInt32(result);
        }

        return -Convert.ToInt32(result);
    }
}
