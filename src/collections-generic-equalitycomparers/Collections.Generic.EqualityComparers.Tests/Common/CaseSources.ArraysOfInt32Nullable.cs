#pragma warning disable IDE0300 // Simplify collection initialization

using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

partial class CaseSources
{
    private static IEnumerable<(int?[]? X, int?[]? Y)> EqualArraysOfInt32Nullable()
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
            EmptyArray<int?>.Create(),
            EmptyArray<int?>.Create()
        );
        yield return (
            new int?[] { null },
            new int?[] { null }
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

    private static IEnumerable<(int?[]? X, int?[]? Y)> NotEqualArraysOfInt32Nullable()
    {
        yield return (
            null,
            EmptyArray<int?>.Value);
        yield return (
            EmptyArray<int?>.Value,
            null);
        yield return (
            null,
            new int?[] { 1 }
        );
        yield return (
            new int?[] { 1 },
            null
        );
        yield return (
            EmptyArray<int?>.Value,
            new int?[] { 1 }
        );
        yield return (
            new int?[] { 1 },
            EmptyArray<int?>.Value
        );
        yield return (
            new int?[] { 1 },
            new int?[] { 1, 2 }
        );
        yield return (
            new int?[] { 1, 2 },
            new int?[] { 1 }
        );
        yield return (
            new int?[] { 1, 2 },
            new int?[] { 1, 2, 3 }
        );
        yield return (
            new int?[] { 1, 2, 3 },
            new int?[] { 1, 2 }
        );
        yield return (
            new int?[] { 1, 2, 3 },
            new int?[] { 1, 2, 3, 4 }
        );
        yield return (
            new int?[] { 1, 2, 3, 4 },
            new int?[] { 1, 2, 3 }
        );
        yield return (
            new int?[] { null },
            new int?[] { 1 }
        );
        yield return (
            new int?[] { 1 },
            new int?[] { null }
        );
        yield return (
            new int?[] { 1, 2, 3, 3 },
            new int?[] { 1, 2, 3, 4 }
        );
        yield return (
            new int?[] { 1, 2, 2, 4 },
            new int?[] { 1, 2, 3, 4 }
        );
        yield return (
            new int?[] { 1, 1, 3, 4 },
            new int?[] { 1, 2, 3, 4 }
        );
        yield return (
            new int?[] { 0, 2, 3, 4 },
            new int?[] { 1, 2, 3, 4 }
        );
    }
}
