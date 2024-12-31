using System.Collections.Generic;
using System.Collections.Immutable;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public abstract class ImmutableArrayEqualityComparer_Nullable_TestsBase<T> : ImmutableArrayEqualityComparer_TestsBase<T>
{
    [Fact]
    public static void Test_GetHashCode_InputIsNull_ExpectZero()
    {
        var comparer = BuildComparer();
        ImmutableArray<T>? nullObj = null;
        var actual = comparer.GetHashCode(nullObj);
        Assert.StrictEqual(0, actual);
    }

    [Fact]
    public static void Test_GetHashCode_InputIsWrappedDefault_ExpectZero()
    {
        var comparer = BuildComparer();
        var actual = comparer.GetHashCode(new ImmutableArray<T>?(default));
        Assert.StrictEqual(0, actual);
    }

    [Theory]
    [MemberData(nameof(InputsAreEqualCases))]
    public static void Test_GetHashCode_InputsAreEqual_ExpectHashCodesAreEqual(CaseParamOfImmutableArrayNullable<T> input1, CaseParamOfImmutableArrayNullable<T> input2)
    {
        var comparer = BuildComparer();
        var hashCode1 = comparer.GetHashCode(input1.Items);
        var hashCode2 = comparer.GetHashCode(input2.Items);
        Assert.StrictEqual(hashCode1, hashCode2);
    }

    [Theory]
    [MemberData(nameof(GetHashCode_InputsAreNotEqualCases))]
    public static void Test_GetHashCode_InputsAreNotEqual_ExpectHashCodesAreNotEqual(CaseParamOfImmutableArrayNullable<T> input1, CaseParamOfImmutableArrayNullable<T> input2)
    {
        var comparer = BuildComparer();
        var hashCode1 = comparer.GetHashCode(input1.Items);
        var hashCode2 = comparer.GetHashCode(input2.Items);
        Assert.NotStrictEqual(hashCode1, hashCode2);
    }

    [Theory]
    [MemberData(nameof(InputsAreEqualCases))]
    public static void Test_Equals_InputsAreEqual_ExpectTrue(CaseParamOfImmutableArrayNullable<T> input1, CaseParamOfImmutableArrayNullable<T> input2)
    {
        var comparer = BuildComparer();
        var actualEquals = comparer.Equals(input1.Items, input2.Items);
        Assert.True(actualEquals);
    }

    [Theory]
    [MemberData(nameof(Equals_InputsAreNotEqualCases))]
    public static void Test_Equals_InputsAreNotEqual_ExpectTrue(CaseParamOfImmutableArrayNullable<T> input1, CaseParamOfImmutableArrayNullable<T> input2)
    {
        var comparer = BuildComparer();
        var actualEquals = comparer.Equals(input1.Items, input2.Items);
        Assert.False(actualEquals);
    }

    public static TheoryData<CaseParamOfImmutableArrayNullable<T>, CaseParamOfImmutableArrayNullable<T>> InputsAreEqualCases()
        =>
        MapEqualsCases(CaseSources.EqualArrays<T>());

    public static TheoryData<CaseParamOfImmutableArrayNullable<T>, CaseParamOfImmutableArrayNullable<T>> GetHashCode_InputsAreNotEqualCases()
        =>
        MapEqualsCases(CaseSources.GetHashCode_NotEqualArrays<T>());

    public static TheoryData<CaseParamOfImmutableArrayNullable<T>, CaseParamOfImmutableArrayNullable<T>> Equals_InputsAreNotEqualCases()
        =>
        MapEqualsCases(CaseSources.Equals_NotEqualArrays<T>());

    private static TheoryData<CaseParamOfImmutableArrayNullable<T>, CaseParamOfImmutableArrayNullable<T>> MapEqualsCases(
        IEnumerable<(T[]? X, T[]? Y)> cases)
    {
        var result = new TheoryData<CaseParamOfImmutableArrayNullable<T>, CaseParamOfImmutableArrayNullable<T>>();
        foreach (var (X, Y) in cases)
        {
            foreach (var (x, y) in CaseParamsMapper.MapToOfImmutableArrayNullable(X, Y))
            {
                result.Add(x, y);
            }
        }
        return result;
    }
}
