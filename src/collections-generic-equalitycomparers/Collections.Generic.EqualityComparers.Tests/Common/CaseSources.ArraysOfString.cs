﻿#pragma warning disable IDE0300 // Simplify collection initialization

using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

partial class CaseSources
{
    private static IEnumerable<(string?[]? X, string?[]? Y)> EqualArraysOfString()
    {
        // Equal by reference

        yield return (
            null,
            null
        );
        yield return (
            EmptyArray<string>.Value,
            EmptyArray<string>.Value
        );
        var array1 = new[] { "1" };
        var array2 = new[] { "1", "2" };
        var array3 = new[] { "1", "2", "3" };
        var array4 = new[] { "1", "2", "3", "4" };
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
            EmptyArray<string>.Create(),
            EmptyArray<string>.Create()
        );
        yield return (
            new[] { (string?)null },
            new[] { (string?)null }
        );
        yield return (
            new[] { "1" },
            new[] { "1" }
        );
        yield return (
            new[] { "1", "2" },
            new[] { "1", "2" }
        );
        yield return (
            new[] { "1", "2", "3" },
            new[] { "1", "2", "3" }
        );
        yield return (
            new[] { "1", "2", "3", "4" },
            new[] { "1", "2", "3", "4" }
        );
    }

    private static IEnumerable<(string?[]? X, string?[]? Y)> NotEqualArraysOfString()
    {
        yield return (
            null,
            new[] { "1" }
        );
        yield return (
            new[] { "1" },
            null
        );
        yield return (
            EmptyArray<string>.Value,
            new[] { "1" }
        );
        yield return (
            new[] { "1" },
            EmptyArray<string>.Value
        );
        yield return (
            new[] { "1" },
            new[] { "1", "2" }
        );
        yield return (
            new[] { "1", "2" },
            new[] { "1" }
        );
        yield return (
            new[] { "1", "2" },
            new[] { "1", "2", "3" }
        );
        yield return (
            new[] { "1", "2", "3" },
            new[] { "1", "2" }
        );
        yield return (
            new[] { "1", "2", "3" },
            new[] { "1", "2", "3", "4" }
        );
        yield return (
            new[] { "1", "2", "3", "4" },
            new[] { "1", "2", "3" }
        );
        yield return (
            new[] { (string?)null },
            new[] { "1" }
        );
        yield return (
            new[] { "1" },
            new[] { (string?)null }
        );
        yield return (
            new[] { "1", "2", "3", "3" },
            new[] { "1", "2", "3", "4" }
        );
        yield return (
            new[] { "1", "2", "2", "4" },
            new[] { "1", "2", "3", "4" }
        );
        yield return (
            new[] { "1", "1", "3", "4" },
            new[] { "1", "2", "3", "4" }
        );
        yield return (
            new[] { "0", "2", "3", "4" },
            new[] { "1", "2", "3", "4" }
        );
    }
}