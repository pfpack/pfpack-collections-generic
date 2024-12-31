using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

partial class CaseSources
{
    internal static IEnumerable<(T[]? X, T[]? Y)> EqualArrays<T>()
        =>
        InnerEqualArrays<T>();
}
