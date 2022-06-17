﻿using SnapSoftInterview.DAL;
using SnapSoftInterview.Model;

namespace SnapSoftInterview.Repository;

public class ProductRepository : IProductRepository
{
    private static readonly Func<IEnumerable<int>, int> CalculateProductValue = (input) => input.Aggregate(1, (actualProduct, next) => checked(actualProduct * next));

    public async Task CalculateAAsync(Product product)
    {
        await Task.Run(() =>
        {
            if (product.Input.Contains(0))
            {
                product.Output = Enumerable.Repeat(0, product.Input.Length).ToArray();
                LogProduct(product);
                return;
            }

            int productValue = CalculateProductValue(product.Input);

            product.Output = product.Input.Select(x => productValue / x).ToArray();
            LogProduct(product);
        });
    }

    public async Task CalculateBAsync(Product product)
    {
        await Task.Run(() =>
        {
            if (product.Input.Contains(0))
            {
                product.Output = Enumerable.Repeat(0, product.Input.Length).ToArray();
                LogProduct(product);
                return;
            }

            var result = new int[product.Input.Length];
            for (int i = 0; i < product.Input.Length; i++)
            {
                result[i] = CalculateProductValue(product.Input.Select((x, index) => i != index ? x : 1));
            }

            product.Output = result;
            LogProduct(product);
        });
    }

    public async Task CalculateCAsync(Product product)
    {
        await Task.Run(() =>
        {
            if (product.Input.Contains(0))
            {
                product.Output = Enumerable.Repeat(0, product.Input.Length).ToArray();
                LogProduct(product);
                return;
            }

            int productValue = CalculateProductValue(product.Input);

            product.Output = product.Input.Select(x => productValue.CheatDivide(x)).ToArray();
            LogProduct(product);
        });
    }

    public async Task<IEnumerable<Product>> GetProductsAsync(string filter)
    {
        return await Task.Run(() =>
        {
            return new List<Product>();
        });
    }

    public async Task LogProduct(Product product)
    {
        try
        {
            using (var context = new ProductContext())
            {
                await context.Products.AddAsync(product);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error while saving product log: {e.Message}");
        }
    }
}

internal static class HelperExtensionMethods
{
    internal static int CheatDivide(this int numerator, int denominator)
    {
        ulong numeratorUlong = Convert.ToUInt64(Math.Abs(numerator));
        ulong denominatorUlong = Convert.ToUInt64(Math.Abs(denominator));

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
