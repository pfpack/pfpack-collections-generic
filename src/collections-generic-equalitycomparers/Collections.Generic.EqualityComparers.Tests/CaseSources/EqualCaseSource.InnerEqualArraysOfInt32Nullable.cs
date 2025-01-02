#pragma warning disable IDE0300 // Simplify collection initialization

using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

partial class EqualCaseSource
{
    private static IEnumerable<(int?[]? X, int?[]? Y)> InnerEqualArraysOfInt32Nullable()
    {
        // Equal by reference

        yield return (
            null,
            null
        );
        yield return (
            EmptyArray<int?>.Value,
            EmptyArray<int?>.Value
        );
        var array1 = new int?[] { 1 };
        var array2 = new int?[] { 1, 2 };
        var array3 = new int?[] { 1, 2, 3 };
        var array4 = new int?[] { 1, 2, 3, 4 };
        yield return (
            array1,
            array1
        );
        yield return (
            array2,
            array2
        );
        yield return (
            array3,
            array3
        );
        yield return (
            array4,
            array4
        );

        // Equal by value

        yield return (
            new int?[] { null },
            new int?[] { null }
        );
        yield return (
            EmptyArray<int?>.Create(),
            EmptyArray<int?>.Create()
        );
        yield return (
            new int?[] { 1 },
            new int?[] { 1 }
        );
        yield return (
            new int?[] { 1, 2 },
            new int?[] { 1, 2 }
        );
        yield return (
            new int?[] { 1, 2, 3 },
            new int?[] { 1, 2, 3 }
        );
        yield return (
            new int?[] { 1, 2, 3, 4 },
            new int?[] { 1, 2, 3, 4 }
        );
    }
}
