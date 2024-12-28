using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public abstract class ListEqualityComparer_List_TestsBase<T> : ListEqualityComparer_TestsBase<T>
{
    [Fact]
    public static void Test_GetHashCode_InputIsNull_ExpectZero()
    {
        var comparer = BuildComparer();
        List<T>? nullObj = null;
        var actual = comparer.GetHashCode(nullObj);
        Assert.StrictEqual(0, actual);
    }

    [Theory]
    [MemberData(nameof(InputsAreEqualCases))]
    public static void Test_GetHashCode_InputsAreEqual_ExpectHashCodesAreEqual(CaseParamOfList<T> input1, CaseParamOfList<T> input2)
    {
        var comparer = BuildComparer();
        var hashCode1 = comparer.GetHashCode(input1.Items);
        var hashCode2 = comparer.GetHashCode(input2.Items);
        Assert.StrictEqual(hashCode1, hashCode2);
    }

    [Theory]
    [MemberData(nameof(InputsAreEqualCases))]
    public static void Test_Equals_InputsAreEqual_ExpectTrue(CaseParamOfList<T> input1, CaseParamOfList<T> input2)
    {
        var comparer = BuildComparer();
        var actualEquals = comparer.Equals(input1.Items, input2.Items);
        Assert.True(actualEquals);
    }

    [Theory]
    [MemberData(nameof(InputsAreNotEqualCases))]
    public static void Test_Equals_InputsAreNotEqual_ExpectTrue(CaseParamOfList<T> input1, CaseParamOfList<T> input2)
    {
        var comparer = BuildComparer();
        var actualEquals = comparer.Equals(input1.Items, input2.Items);
        Assert.False(actualEquals);
    }

    public static TheoryData<CaseParamOfList<T>, CaseParamOfList<T>> InputsAreEqualCases()
        =>
        MapEqualsCases(CaseSources.EqualArrays<T>());

    public static TheoryData<CaseParamOfList<T>, CaseParamOfList<T>> InputsAreNotEqualCases()
        =>
        MapEqualsCases(CaseSources.NotEqualArrays<T>());

    private static TheoryData<CaseParamOfList<T>, CaseParamOfList<T>> MapEqualsCases(
        IEnumerable<(T[]? X, T[]? Y)> cases)
    {
        var result = new TheoryData<CaseParamOfList<T>, CaseParamOfList<T>>();
        foreach (var (X, Y) in cases)
        {
            var (x, y) = CaseParamsMapper.MapToOfList(X, Y);
            result.Add(x, y);
        }
        return result;
    }
}
