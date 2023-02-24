﻿using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ImmutableArrayEqualityComparer.Nullable;

public abstract class EqualityComparerTestsBase_Ref : EqualityComparerTestsBase<string>
{
    protected EqualityComparerTestsBase_Ref(Func<ListEqualityComparer<string>> comparerFactory)
        : base(comparerFactory)
    {
    }

    [Theory]
    [MemberData(nameof(SourceAreEqualCases))]
    public void Test_GetHashCode_SourceAreEqual_ExpectHashCodesAreEqual(CaseParam<string> source1, CaseParam<string> source2)
    {
        var hashCode1 = comparer.GetHashCode(source1.Items);
        var hashCode2 = comparer.GetHashCode(source2.Items);
        Assert.StrictEqual(hashCode1, hashCode2);
    }

    [Theory]
    [MemberData(nameof(SourceAreEqualCases))]
    public void Test_Equals_SourceAreEqual_ExpectTrue(CaseParam<string> source1, CaseParam<string> source2)
    {
        var actualEquals = comparer.Equals(source1.Items, source2.Items);
        Assert.True(actualEquals);
    }

    [Theory]
    [MemberData(nameof(SourceAreNotEqualCases))]
    public void Test_Equals_SourceAreNotEqual_ExpectTrue(CaseParam<string> source1, CaseParam<string> source2)
    {
        var actualEquals = comparer.Equals(source1.Items, source2.Items);
        Assert.False(actualEquals);
    }

    public static IEnumerable<object[]> SourceAreEqualCases()
        =>
        EnumerateSourceAreEqualCases().Select(
            @case => new object[]
            {
                new CaseParam<string>(@case[0]),
                new CaseParam<string>(@case[1]),
            });

    public static IEnumerable<object[]> SourceAreNotEqualCases()
        =>
        EnumerateSourceAreNotEqualCases().Select(
            @case => new object[]
            {
                new CaseParam<string>(@case[0]),
                new CaseParam<string>(@case[1]),
            });

    private static IEnumerable<IList<string>[]> EnumerateSourceAreEqualCases()
    {
        yield return new[]
        {
            CustomList<string>.Empty,
            CustomList<string>.Empty,
        };
        yield return new[]
        {
            new CustomList<string>(),
            new CustomList<string>(),
        };
        yield return new[]
        {
            CustomList.Create("1"),
            CustomList.Create("1"),
        };
        yield return new[]
        {
            CustomList.Create("1", "2"),
            CustomList.Create("1", "2"),
        };
        yield return new[]
        {
            CustomList.Create("1", "2", "3"),
            CustomList.Create("1", "2", "3"),
        };
        yield return new[]
        {
            CustomList.Create("1", "2", "3", "4"),
            CustomList.Create("1", "2", "3", "4"),
        };

        var array1 = CustomList.Create("1");
        var array2 = CustomList.Create("1", "2");
        var array3 = CustomList.Create("1", "2", "3");
        var array4 = CustomList.Create("1", "2", "3", "4");
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

    private static IEnumerable<IList<string>[]> EnumerateSourceAreNotEqualCases()
    {
        yield return new[]
        {
            CustomList<string>.Empty,
            CustomList.Create("1"),
        };
        yield return new[]
        {
            CustomList.Create("1"),
            CustomList<string>.Empty,
        };
        yield return new[]
        {
            CustomList.Create("1"),
            CustomList.Create("1", "2"),
        };
        yield return new[]
        {
            CustomList.Create("1", "2"),
            CustomList.Create("1"),
        };
        yield return new[]
        {
            CustomList.Create("1", "2"),
            CustomList.Create("1", "2", "3"),
        };
        yield return new[]
        {
            CustomList.Create("1", "2", "3"),
            CustomList.Create("1", "2"),
        };
        yield return new[]
        {
            CustomList.Create("1", "2", "3"),
            CustomList.Create("1", "2", "3", "4"),
        };
        yield return new[]
        {
            CustomList.Create("1", "2", "3", "4"),
            CustomList.Create("1", "2", "3"),
        };
    }
}
