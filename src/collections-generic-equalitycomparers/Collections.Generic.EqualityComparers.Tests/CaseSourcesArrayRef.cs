using System.Collections.Generic;
using System.Linq;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

internal static class CaseSourcesArrayRef
{
    internal static IEnumerable<CaseParamOfArray<string?>[]> SourceAreEqualCases()
        =>
        InnerSourceAreEqualCases().Select(InnerMapCase);

    internal static IEnumerable<CaseParamOfArray<string?>[]> SourceAreNotEqualCases()
        =>
        InnerSourceAreNotEqualCases().Select(InnerMapCase);

    private static CaseParamOfArray<string?>[] InnerMapCase(string?[]?[] @case)
        =>
        @case.Select(caseParam => new CaseParamOfArray<string?>(caseParam)).ToArray();

    private static IEnumerable<string?[]?[]> InnerSourceAreEqualCases()
    {
        yield return new string[]?[]
        {
            null,
            null,
        };
        yield return new[]
        {
            EmptyArray<string>.Value,
            EmptyArray<string>.Value,
        };
        yield return new[]
        {
            EmptyArray<string>.Create(),
            EmptyArray<string>.Create(),
        };
        yield return new[]
        {
            new[] { (string?)null },
            new[] { (string?)null },
        };
        yield return new[]
        {
            new[] { "1" },
            new[] { "1" },
        };
        yield return new[]
        {
            new[] { "1", "2" },
            new[] { "1", "2" },
        };
        yield return new[]
        {
            new[] { "1", "2", "3" },
            new[] { "1", "2", "3" },
        };
        yield return new[]
        {
            new[] { "1", "2", "3", "4" },
            new[] { "1", "2", "3", "4" },
        };

        var array1 = new[] { "1" };
        var array2 = new[] { "1", "2" };
        var array3 = new[] { "1", "2", "3" };
        var array4 = new[] { "1", "2", "3", "4" };
        yield return new[]
        {
            array1,
            array1,
        };
        yield return new[]
        {
            array2,
            array2,
        };
        yield return new[]
        {
            array3,
            array3,
        };
        yield return new[]
        {
            array4,
            array4,
        };
    }

    private static IEnumerable<string?[]?[]> InnerSourceAreNotEqualCases()
    {
        yield return new[]
        {
            null,
            new[] { "1" },
        };
        yield return new[]
        {
            new[] { "1" },
            null,
        };
        yield return new[]
        {
            EmptyArray<string>.Value,
            new[] { "1" },
        };
        yield return new[]
        {
            new[] { "1" },
            EmptyArray<string>.Value,
        };
        yield return new[]
        {
            new[] { "1" },
            new[] { "1", "2" },
        };
        yield return new[]
        {
            new[] { "1", "2" },
            new[] { "1" },
        };
        yield return new[]
        {
            new[] { "1", "2" },
            new[] { "1", "2", "3" },
        };
        yield return new[]
        {
            new[] { "1", "2", "3" },
            new[] { "1", "2" },
        };
        yield return new[]
        {
            new[] { "1", "2", "3" },
            new[] { "1", "2", "3", "4" },
        };
        yield return new[]
        {
            new[] { "1", "2", "3", "4" },
            new[] { "1", "2", "3" },
        };
        yield return new[]
        {
            new[] { (string?)null },
            new[] { "1" },
        };
        yield return new[]
        {
            new[] { "1", "2", "3", "3" },
            new[] { "1", "2", "3", "4" },
        };
        yield return new[]
        {
            new[] { "1", "2", "2", "4" },
            new[] { "1", "2", "3", "4" },
        };
        yield return new[]
        {
            new[] { "1", "1", "3", "4" },
            new[] { "1", "2", "3", "4" },
        };
        yield return new[]
        {
            new[] { "0", "2", "3", "4" },
            new[] { "1", "2", "3", "4" },
        };
    }
}
