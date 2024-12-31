using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

partial class CaseSources
{
    // Here it is assumed a small set consisting of short arrays
    // should lead to different hash codes with no collisions
    internal static IEnumerable<(T[]? X, T[]? Y)> GetHashCode_NotEqualArrays<T>()
        =>
        InnerNotEqualArrays<T>();
}
