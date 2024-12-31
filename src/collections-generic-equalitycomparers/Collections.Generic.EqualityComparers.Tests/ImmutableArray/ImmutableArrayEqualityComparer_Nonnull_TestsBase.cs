using System.Collections.Generic;
using System.Collections.Immutable;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public abstract class ImmutableArrayEqualityComparer_Nonnull_TestsBase<T> : ImmutableArrayEqualityComparer_TestsBase<T>
{
    [Fact]
    public static void Test_GetHashCode_InputIsDefault_ExpectZero()
    {
        var comparer = BuildComparer();
        ImmutableArray<T> nullObj = default;
        var actual = comparer.GetHashCode(nullObj);
        Assert.StrictEqual(0, actual);
    }

    [Theory]
    [MemberData(nameof(InputsAreEqualCases))]
    public static void Test_GetHashCode_InputsAreEqual_ExpectHashCodesAreEqual(CaseParamOfImmutableArray<T> input1, CaseParamOfImmutableArray<T> input2)
    {
        var comparer = BuildComparer();
        var hashCode1 = comparer.GetHashCode(input1.Items);
        var hashCode2 = comparer.GetHashCode(input2.Items);
        Assert.StrictEqual(hashCode1, hashCode2);
    }

    [Theory]
    [MemberData(nameof(GetHashCode_InputsAreNotEqualCases))]
    public static void Test_GetHashCode_InputsAreNotEqual_ExpectHashCodesAreNotEqual(CaseParamOfImmutableArray<T> input1, CaseParamOfImmutableArray<T> input2)
    {
        var comparer = BuildComparer();
        var hashCode1 = comparer.GetHashCode(input1.Items);
        var hashCode2 = comparer.GetHashCode(input2.Items);
        Assert.NotStrictEqual(hashCode1, hashCode2);
    }

    [Theory]
    [MemberData(nameof(InputsAreEqualCases))]
    public static void Test_Equals_InputsAreEqual_ExpectTrue(CaseParamOfImmutableArray<T> input1, CaseParamOfImmutableArray<T> input2)
    {
        var comparer = BuildComparer();
        var actualEquals = comparer.Equals(input1.Items, input2.Items);
        Assert.True(actualEquals);
    }

    [Theory]
    [MemberData(nameof(Equals_InputsAreNotEqualCases))]
    public static void Test_Equals_InputsAreNotEqual_ExpectTrue(CaseParamOfImmutableArray<T> input1, CaseParamOfImmutableArray<T> input2)
    {
        var comparer = BuildComparer();
        var actualEquals = comparer.Equals(input1.Items, input2.Items);
        Assert.False(actualEquals);
    }

    public static TheoryData<CaseParamOfImmutableArray<T>, CaseParamOfImmutableArray<T>> InputsAreEqualCases()
        =>
        MapEqualsCases(CaseSources.EqualArrays<T>());

    public static TheoryData<CaseParamOfImmutableArray<T>, CaseParamOfImmutableArray<T>> Equals_InputsAreNotEqualCases()
        =>
        MapEqualsCases(CaseSources.Equals_NotEqualArrays<T>());

    public static TheoryData<CaseParamOfImmutableArray<T>, CaseParamOfImmutableArray<T>> GetHashCode_InputsAreNotEqualCases()
        =>
        MapEqualsCases(CaseSources.GetHashCode_NotEqualArrays<T>());

    private static TheoryData<CaseParamOfImmutableArray<T>, CaseParamOfImmutableArray<T>> MapEqualsCases(
        IEnumerable<(T[]? X, T[]? Y)> cases)
    {
        var result = new TheoryData<CaseParamOfImmutableArray<T>, CaseParamOfImmutableArray<T>>();
        foreach (var (X, Y) in cases)
        {
            var (x, y) = CaseParamsMapper.MapToOfImmutableArray(X, Y);
            result.Add(x, y);
        }
        return result;
    }
}
