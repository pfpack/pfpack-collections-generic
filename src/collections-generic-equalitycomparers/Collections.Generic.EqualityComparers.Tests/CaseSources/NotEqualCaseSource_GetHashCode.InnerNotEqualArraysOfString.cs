#pragma warning disable IDE0300 // Simplify collection initialization

using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

partial class NotEqualCaseSource_GetHashCode
{
    private static IEnumerable<(string?[]? X, string?[]? Y)> InnerNotEqualArraysOfString()
    {
        yield return (
            null,
            EmptyArray<string>.Value);
        yield return (
            null,
            new[] { "1" }
        );
        yield return (
            EmptyArray<string>.Value,
            new[] { "1" }
        );
        yield return (
            new[] { "1" },
            new[] { "1", "2" }
        );
        yield return (
            new[] { "1", "2" },
            new[] { "1", "2", "3" }
        );
        yield return (
            new[] { (string?)null },
            new[] { "1" }
        );
        yield return (
            new[] { "1" },
            new[] { "2" }
        );
        yield return (
            new[] { "1", "2" },
            new[] { "1", "1" }
        );
        yield return (
            new[] { "1", "2", "3" },
            new[] { "1", "0", "3" }
        );
    }
}
