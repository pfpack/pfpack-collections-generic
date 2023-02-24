using System;
using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ArrayEqualityComparer;

public abstract class EqualityComparerTestsBase_Ref : EqualityComparerTestsBase<string>
{
    protected EqualityComparerTestsBase_Ref(Func<ArrayEqualityComparer<string>> comparerFactory)
        : base(comparerFactory)
    {
    }

    [Theory]
    [MemberData(nameof(SourceAreEqualCases))]
    public void Test_GetHashCode_SourceAreEqual_ExpectHashCodesAreEqual(string[] source1, string[] source2)
    {
        var hashCode1 = comparer.GetHashCode(source1);
        var hashCode2 = comparer.GetHashCode(source2);
        Assert.StrictEqual(hashCode1, hashCode2);
    }

    [Theory]
    [MemberData(nameof(SourceAreEqualCases))]
    public void Test_Equals_SourceAreEqual_ExpectTrue(string[] source1, string[] source2)
    {
        var actualEquals = comparer.Equals(source1, source2);
        Assert.True(actualEquals);
    }

    [Theory]
    [MemberData(nameof(SourceAreNotEqualCases))]
    public void Test_Equals_SourceAreNotEqual_ExpectTrue(string[] source1, string[] source2)
    {
        var actualEquals = comparer.Equals(source1, source2);
        Assert.False(actualEquals);
    }

    public static IEnumerable<object[]> SourceAreEqualCases()
    {
        yield return new object[]
        {
            Array.Empty<string>(),
            Array.Empty<string>(),
        };
        yield return new object[]
        {
            EmptyArray<string>.Value,
            EmptyArray<string>.Value,
        };
        yield return new object[]
        {
            Array.Empty<string>(),
            EmptyArray<string>.Value,
        };
        yield return new object[]
        {
            EmptyArray<string>.Value,
            Array.Empty<string>(),
        };
        yield return new object[]
        {
            EmptyArray<string>.Create(),
            EmptyArray<string>.Create(),
        };
        yield return new object[]
        {
            new[] { "1" },
            new[] { "1" },
        };
        yield return new object[]
        {
            new[] { "1", "2" },
            new[] { "1", "2" },
        };
        yield return new object[]
        {
            new[] { "1", "2", "3" },
            new[] { "1", "2", "3" },
        };
        yield return new object[]
        {
            new[] { "1", "2", "3", "4" },
            new[] { "1", "2", "3", "4" },
        };

        var array1 = new[] { "1" };
        var array2 = new[] { "1", "2" };
        var array3 = new[] { "1", "2", "3" };
        var array4 = new[] { "1", "2", "3", "4" };
        yield return new object[]
        {
            array1,
            array1,
        };
        yield return new object[]
        {
            array2,
            array2,
        };
        yield return new object[]
        {
            array3,
            array3,
        };
        yield return new object[]
        {
            array4,
            array4,
        };
    }

    public static IEnumerable<object[]> SourceAreNotEqualCases()
    {
        yield return new object[]
        {
            Array.Empty<string>(),
            new[] { "1" },
        };
        yield return new object[]
        {
            new[] { "1" },
            Array.Empty<string>(),
        };
        yield return new object[]
        {
            EmptyArray<string>.Value,
            new[] { "1" },
        };
        yield return new object[]
        {
            new[] { "1" },
            EmptyArray<string>.Value,
        };
        yield return new object[]
        {
            new[] { "1" },
            new[] { "1", "2" },
        };
        yield return new object[]
        {
            new[] { "1", "2" },
            new[] { "1" },
        };
        yield return new object[]
        {
            new[] { "1", "2" },
            new[] { "1", "2", "3" },
        };
        yield return new object[]
        {
            new[] { "1", "2", "3" },
            new[] { "1", "2" },
        };
        yield return new object[]
        {
            new[] { "1", "2", "3" },
            new[] { "1", "2", "3", "4" },
        };
        yield return new object[]
        {
            new[] { "1", "2", "3", "4" },
            new[] { "1", "2", "3" },
        };
    }
}
