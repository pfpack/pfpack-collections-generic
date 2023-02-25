using System.Collections.Generic;
using System.Linq;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

internal static class CaseSourcesArrayStruct
{
    public static IEnumerable<CaseParamOfArray<int?>[]> SourceAreEqualCases()
        =>
        InnerSourceAreEqualCases().Select(InnerMapCase);

    public static IEnumerable<CaseParamOfArray<int?>[]> SourceAreNotEqualCases()
        =>
        InnerSourceAreNotEqualCases().Select(InnerMapCase);

    private static CaseParamOfArray<int?>[] InnerMapCase(int?[]?[] @case)
        =>
        @case.Select(caseParam => new CaseParamOfArray<int?>(caseParam)).ToArray();

    private static IEnumerable<int?[]?[]> InnerSourceAreEqualCases()
    {
        yield return new int?[]?[]
        {
            null,
            null,
        };
        yield return new[]
        {
            EmptyArray<int?>.Value,
            EmptyArray<int?>.Value,
        };
        yield return new[]
        {
            EmptyArray<int?>.Create(),
            EmptyArray<int?>.Create(),
        };
        yield return new[]
        {
            new int?[] { null },
            new int?[] { null },
        };
        yield return new[]
        {
            new int?[] { 1 },
            new int?[] { 1 },
        };
        yield return new[]
        {
            new int?[] { 1, 2 },
            new int?[] { 1, 2 },
        };
        yield return new[]
        {
            new int?[] { 1, 2, 3 },
            new int?[] { 1, 2, 3 },
        };
        yield return new[]
        {
            new int?[] { 1, 2, 3, 4 },
            new int?[] { 1, 2, 3, 4 },
        };

        var array1 = new int?[] { 1 };
        var array2 = new int?[] { 1, 2 };
        var array3 = new int?[] { 1, 2, 3 };
        var array4 = new int?[] { 1, 2, 3, 4 };
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

    private static IEnumerable<int?[]?[]> InnerSourceAreNotEqualCases()
    {
        yield return new[]
        {
            null,
            new int?[] { 1 },
        };
        yield return new[]
        {
            new int?[] { 1 },
            null,
        };
        yield return new[]
        {
            EmptyArray<int?>.Value,
            new int?[] { 1 },
        };
        yield return new[]
        {
            new int?[] { 1 },
            EmptyArray<int?>.Value,
        };
        yield return new[]
        {
            new int?[] { 1 },
            new int?[] { 1, 2 },
        };
        yield return new[]
        {
            new int?[] { 1, 2 },
            new int?[] { 1 },
        };
        yield return new[]
        {
            new int?[] { 1, 2 },
            new int?[] { 1, 2, 3 },
        };
        yield return new[]
        {
            new int?[] { 1, 2, 3 },
            new int?[] { 1, 2 },
        };
        yield return new[]
        {
            new int?[] { 1, 2, 3 },
            new int?[] { 1, 2, 3, 4 },
        };
        yield return new[]
        {
            new int?[] { 1, 2, 3, 4 },
            new int?[] { 1, 2, 3 },
        };
        yield return new[]
        {
            new int?[] { null },
            new int?[] { 1 },
        };
        yield return new[]
        {
            new int?[] { 1, 2, 3, 3 },
            new int?[] { 1, 2, 3, 4 },
        };
        yield return new[]
        {
            new int?[] { 1, 2, 2, 4 },
            new int?[] { 1, 2, 3, 4 },
        };
        yield return new[]
        {
            new int?[] { 1, 1, 3, 4 },
            new int?[] { 1, 2, 3, 4 },
        };
        yield return new[]
        {
            new int?[] { 0, 2, 3, 4 },
            new int?[] { 1, 2, 3, 4 },
        };
    }
}
