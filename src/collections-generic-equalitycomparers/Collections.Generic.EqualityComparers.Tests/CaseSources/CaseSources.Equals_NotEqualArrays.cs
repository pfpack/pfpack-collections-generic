using System.Collections.Generic;
using System.Linq;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

partial class CaseSources
{
    internal static IEnumerable<(T[]? X, T[]? Y)> Equals_NotEqualArrays<T>()
        =>
        InnerNotEqualArrays<T>().ToArray() switch
        {
            var pairs => pairs.Concat(pairs.Select(pair => (pair.Y, pair.X)))
        };
}
