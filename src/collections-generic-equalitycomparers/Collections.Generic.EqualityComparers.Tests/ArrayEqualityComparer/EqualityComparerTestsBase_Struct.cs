using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ArrayEqualityComparer;

public abstract class EqualityComparerTestsBase_Struct : EqualityComparerTestsBase<int>
{
    protected EqualityComparerTestsBase_Struct(Func<ArrayEqualityComparer<int>> comparerFactory)
        : base(comparerFactory)
    {
    }

    [Theory]
    [MemberData(nameof(SourceAreEqualCases))]
    public void Test_GetHashCode_SourceAreEqual_ExpectHashCodesAreEqual(CaseParam<int> source1, CaseParam<int> source2)
    {
        var hashCode1 = comparer.GetHashCode(source1.Items);
        var hashCode2 = comparer.GetHashCode(source2.Items);
        Assert.StrictEqual(hashCode1, hashCode2);
    }

    [Theory]
    [MemberData(nameof(SourceAreEqualCases))]
    public void Test_Equals_SourceAreEqual_ExpectTrue(CaseParam<int> source1, CaseParam<int> source2)
    {
        var actualEquals = comparer.Equals(source1.Items, source2.Items);
        Assert.True(actualEquals);
    }

    [Theory]
    [MemberData(nameof(SourceAreNotEqualCases))]
    public void Test_Equals_SourceAreNotEqual_ExpectTrue(CaseParam<int> source1, CaseParam<int> source2)
    {
        var actualEquals = comparer.Equals(source1.Items, source2.Items);
        Assert.False(actualEquals);
    }

    public static IEnumerable<object[]> SourceAreEqualCases()
        =>
        EnumerateSourceAreEqualCases().Select(
            @case => new object[]
            {
                new CaseParam<int>(@case[0]),
                new CaseParam<int>(@case[1]),
            });

    public static IEnumerable<object[]> SourceAreNotEqualCases()
        =>
        EnumerateSourceAreNotEqualCases().Select(
            @case => new object[]
            {
                new CaseParam<int>(@case[0]),
                new CaseParam<int>(@case[1]),
            });

    private static IEnumerable<int[][]> EnumerateSourceAreEqualCases()
    {
        yield return new int[][]
        {
            Array.Empty<int>(),
            Array.Empty<int>(),
        };
        yield return new int[][]
        {
            EmptyArray<int>.Value,
            EmptyArray<int>.Value,
        };
        yield return new int[][]
        {
            Array.Empty<int>(),
            EmptyArray<int>.Value,
        };
        yield return new int[][]
        {
            EmptyArray<int>.Value,
            Array.Empty<int>(),
        };
        yield return new int[][]
        {
            EmptyArray<int>.Create(),
            EmptyArray<int>.Create(),
        };
        yield return new int[][]
        {
            new[] { 1 },
            new[] { 1 },
        };
        yield return new int[][]
        {
            new[] { 1, 2 },
            new[] { 1, 2 },
        };
        yield return new int[][]
        {
            new[] { 1, 2, 3 },
            new[] { 1, 2, 3 },
        };
        yield return new int[][]
        {
            new[] { 1, 2, 3, 4 },
            new[] { 1, 2, 3, 4 },
        };

        var array1 = new[] { 1 };
        var array2 = new[] { 1, 2 };
        var array3 = new[] { 1, 2, 3 };
        var array4 = new[] { 1, 2, 3, 4 };
        yield return new int[][]
        {
            array1,
            array1,
        };
        yield return new int[][]
        {
            array2,
            array2,
        };
        yield return new int[][]
        {
            array3,
            array3,
        };
        yield return new int[][]
        {
            array4,
            array4,
        };
    }

    private static IEnumerable<int[][]> EnumerateSourceAreNotEqualCases()
    {
        yield return new int[][]
        {
            Array.Empty<int>(),
            new[] { 1 },
        };
        yield return new int[][]
        {
            new[] { 1 },
            Array.Empty<int>(),
        };
        yield return new int[][]
        {
            EmptyArray<int>.Value,
            new[] { 1 },
        };
        yield return new int[][]
        {
            new[] { 1 },
            EmptyArray<int>.Value,
        };
        yield return new int[][]
        {
            new[] { 1 },
            new[] { 1, 2 },
        };
        yield return new int[][]
        {
            new[] { 1, 2 },
            new[] { 1 },
        };
        yield return new int[][]
        {
            new[] { 1, 2 },
            new[] { 1, 2, 3 },
        };
        yield return new int[][]
        {
            new[] { 1, 2, 3 },
            new[] { 1, 2 },
        };
        yield return new int[][]
        {
            new[] { 1, 2, 3 },
            new[] { 1, 2, 3, 4 },
        };
        yield return new int[][]
        {
            new[] { 1, 2, 3, 4 },
            new[] { 1, 2, 3 },
        };
    }
}
