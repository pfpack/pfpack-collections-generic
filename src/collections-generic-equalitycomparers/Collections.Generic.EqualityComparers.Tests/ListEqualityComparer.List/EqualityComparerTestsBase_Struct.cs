using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ListEqualityComparer.List;

public abstract class EqualityComparerTestsBase_Struct : EqualityComparerTestsBase<int>
{
    protected EqualityComparerTestsBase_Struct(Func<ReadOnlyListEqualityComparer<int>> comparerFactory)
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

    private static IEnumerable<IReadOnlyList<int>[]> EnumerateSourceAreEqualCases()
    {
        yield return new[]
        {
            CustomReadOnlyList<int>.Empty,
            CustomReadOnlyList<int>.Empty,
        };
        yield return new[]
        {
            new CustomReadOnlyList<int>(),
            new CustomReadOnlyList<int>(),
        };
        yield return new[]
        {
            CustomReadOnlyList.Create(1),
            CustomReadOnlyList.Create(1),
        };
        yield return new[]
        {
            CustomReadOnlyList.Create(1, 2),
            CustomReadOnlyList.Create(1, 2),
        };
        yield return new[]
        {
            CustomReadOnlyList.Create(1, 2, 3),
            CustomReadOnlyList.Create(1, 2, 3),
        };
        yield return new[]
        {
            CustomReadOnlyList.Create(1, 2, 3, 4),
            CustomReadOnlyList.Create(1, 2, 3, 4),
        };

        var array1 = CustomReadOnlyList.Create(1);
        var array2 = CustomReadOnlyList.Create(1, 2);
        var array3 = CustomReadOnlyList.Create(1, 2, 3);
        var array4 = CustomReadOnlyList.Create(1, 2, 3, 4);
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

    private static IEnumerable<IReadOnlyList<int>[]> EnumerateSourceAreNotEqualCases()
    {
        yield return new[]
        {
            CustomReadOnlyList<int>.Empty,
            CustomReadOnlyList.Create(1),
        };
        yield return new[]
        {
            CustomReadOnlyList.Create(1),
            CustomReadOnlyList<int>.Empty,
        };
        yield return new[]
        {
            CustomReadOnlyList.Create(1),
            CustomReadOnlyList.Create(1, 2),
        };
        yield return new[]
        {
            CustomReadOnlyList.Create(1, 2),
            CustomReadOnlyList.Create(1),
        };
        yield return new[]
        {
            CustomReadOnlyList.Create(1, 2),
            CustomReadOnlyList.Create(1, 2, 3),
        };
        yield return new[]
        {
            CustomReadOnlyList.Create(1, 2, 3),
            CustomReadOnlyList.Create(1, 2),
        };
        yield return new[]
        {
            CustomReadOnlyList.Create(1, 2, 3),
            CustomReadOnlyList.Create(1, 2, 3, 4),
        };
        yield return new[]
        {
            CustomReadOnlyList.Create(1, 2, 3, 4),
            CustomReadOnlyList.Create(1, 2, 3),
        };
    }
}
