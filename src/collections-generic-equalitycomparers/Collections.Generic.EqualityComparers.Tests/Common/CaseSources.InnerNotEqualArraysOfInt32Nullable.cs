#pragma warning disable IDE0300 // Simplify collection initialization

using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

partial class CaseSources
{
    private static IEnumerable<(int?[]? X, int?[]? Y)> InnerNotEqualArraysOfInt32Nullable()
    {
        yield return (
            null,
            EmptyArray<int?>.Value);
        yield return (
            null,
            new int?[] { 1 }
        );
        yield return (
            EmptyArray<int?>.Value,
            new int?[] { 1 }
        );
        yield return (
            new int?[] { 1 },
            new int?[] { 1, 2 }
        );
        yield return (
            new int?[] { 1, 2 },
            new int?[] { 1, 2, 3 }
        );
        yield return (
            new int?[] { 1, 2, 3 },
            new int?[] { 1, 2, 3, 4 }
        );
        yield return (
            new int?[] { null },
            new int?[] { 1 }
        );
        yield return (
            new int?[] { 1 },
            new int?[] { 2 }
        );
        yield return (
            new int?[] { 1, 2 },
            new int?[] { 1, 1 }
        );
        yield return (
            new int?[] { 1, 2, 3 },
            new int?[] { 1, 1, 3 }
        );
        yield return (
            new int?[] { 1, 2, 3, 4 },
            new int?[] { 1, 2, 3, 3 }
        );
        yield return (
            new int?[] { 1, 2, 3, 4 },
            new int?[] { 1, 2, 2, 4 }
        );
        yield return (
            new int?[] { 1, 2, 3, 4 },
            new int?[] { 1, 1, 3, 4 }
        );
        yield return (
            new int?[] { 1, 2, 3, 4 },
            new int?[] { 0, 2, 3, 4 }
        );
    }
}
