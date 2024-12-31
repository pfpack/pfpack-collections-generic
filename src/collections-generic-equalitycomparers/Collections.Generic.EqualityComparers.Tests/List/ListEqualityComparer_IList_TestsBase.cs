using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public abstract class ListEqualityComparer_IList_TestsBase<T> : ListEqualityComparer_TestsBase<T>
{
    [Fact]
    public static void Test_GetHashCode_InputIsNull_ExpectZero()
    {
        var comparer = BuildComparer();
        IList<T>? nullObj = null;
        var actual = comparer.GetHashCode(nullObj);
        Assert.StrictEqual(0, actual);
    }

    [Theory]
    [MemberData(nameof(InputsAreEqualCases))]
    public static void Test_GetHashCode_InputsAreEqual_ExpectHashCodesAreEqual(CaseParamOfIList<T> input1, CaseParamOfIList<T> input2)
    {
        var comparer = BuildComparer();
        var hashCode1 = comparer.GetHashCode(input1.Items);
        var hashCode2 = comparer.GetHashCode(input2.Items);
        Assert.StrictEqual(hashCode1, hashCode2);
    }

    [Theory]
    [MemberData(nameof(GetHashCode_InputsAreNotEqualCases))]
    public static void Test_GetHashCode_InputsAreNotEqual_ExpectHashCodesAreNotEqual(CaseParamOfIList<T> input1, CaseParamOfIList<T> input2)
    {
        var comparer = BuildComparer();
        var hashCode1 = comparer.GetHashCode(input1.Items);
        var hashCode2 = comparer.GetHashCode(input2.Items);
        Assert.NotStrictEqual(hashCode1, hashCode2);
    }

    [Theory]
    [MemberData(nameof(InputsAreEqualCases))]
    public static void Test_Equals_InputsAreEqual_ExpectTrue(CaseParamOfIList<T> input1, CaseParamOfIList<T> input2)
    {
        var comparer = BuildComparer();
        var actualEquals = comparer.Equals(input1.Items, input2.Items);
        Assert.True(actualEquals);
    }

    [Theory]
    [MemberData(nameof(Equals_InputsAreNotEqualCases))]
    public static void Test_Equals_InputsAreNotEqual_ExpectFalse(CaseParamOfIList<T> input1, CaseParamOfIList<T> input2)
    {
        var comparer = BuildComparer();
        var actualEquals = comparer.Equals(input1.Items, input2.Items);
        Assert.False(actualEquals);
    }

    public static TheoryData<CaseParamOfIList<T>, CaseParamOfIList<T>> InputsAreEqualCases()
        =>
        MapEqualsCases(CaseSources.EqualArrays<T>());

    public static TheoryData<CaseParamOfIList<T>, CaseParamOfIList<T>> Equals_InputsAreNotEqualCases()
        =>
        MapEqualsCases(CaseSources.Equals_NotEqualArrays<T>());

    public static TheoryData<CaseParamOfIList<T>, CaseParamOfIList<T>> GetHashCode_InputsAreNotEqualCases()
        =>
        MapEqualsCases(CaseSources.GetHashCode_NotEqualArrays<T>());

    private static TheoryData<CaseParamOfIList<T>, CaseParamOfIList<T>> MapEqualsCases(
        IEnumerable<(T[]? X, T[]? Y)> cases)
    {
        var result = new TheoryData<CaseParamOfIList<T>, CaseParamOfIList<T>>();
        foreach (var (X, Y) in cases)
        {
            var (x, y) = CaseParamsMapper.MapToOfIList(X, Y);
            result.Add(x, y);
        }
        return result;
    }
}
