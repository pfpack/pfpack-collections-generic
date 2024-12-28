using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public abstract class ArrayEqualityComparer_TestsBase<T>
{
    [Theory]
    [MemberData(nameof(Test_Factory_ExpectItemComparer_Cases))]
    public static void Test_Factory_ExpectItemComparer(ArrayEqualityComparer<T> comparer, IEqualityComparer<T> expected)
        =>
        FactoryAssert.AssertItemComparer(comparer, expected);

    [Fact]
    public static void Test_GetHashCode_InputIsNull_ExpectZero()
    {
        var comparer = BuildComparer();
        T[]? nullObj = null;
        var actual = comparer.GetHashCode(nullObj);
        Assert.StrictEqual(0, actual);
    }

    [Theory]
    [MemberData(nameof(InputsAreEqualCases))]
    public static void Test_GetHashCode_InputsAreEqual_ExpectHashCodesAreEqual(CaseParamOfArray<T> input1, CaseParamOfArray<T> input2)
    {
        var comparer = BuildComparer();
        var hashCode1 = comparer.GetHashCode(input1.Items);
        var hashCode2 = comparer.GetHashCode(input2.Items);
        Assert.StrictEqual(hashCode1, hashCode2);
    }

    [Theory]
    [MemberData(nameof(InputsAreEqualCases))]
    public static void Test_Equals_InputsAreEqual_ExpectTrue(CaseParamOfArray<T> input1, CaseParamOfArray<T> input2)
    {
        var comparer = BuildComparer();
        var actualEquals = comparer.Equals(input1.Items, input2.Items);
        Assert.True(actualEquals);
    }

    [Theory]
    [MemberData(nameof(InputsAreNotEqualCases))]
    public static void Test_Equals_InputsAreNotEqual_ExpectTrue(CaseParamOfArray<T> input1, CaseParamOfArray<T> input2)
    {
        var comparer = BuildComparer();
        var actualEquals = comparer.Equals(input1.Items, input2.Items);
        Assert.False(actualEquals);
    }

    public static TheoryData<ArrayEqualityComparer<T>, IEqualityComparer<T>> Test_Factory_ExpectItemComparer_Cases => new()
    {
        {
            ArrayEqualityComparer<T>.Default,
            EqualityComparer<T>.Default
        },
        {
            ArrayEqualityComparer<T>.Create(),
            EqualityComparer<T>.Default
        },
        {
            ArrayEqualityComparer<T>.Create(null),
            EqualityComparer<T>.Default
        },
        {
            ArrayEqualityComparer<T>.Create(EqualityComparer<T>.Default),
            EqualityComparer<T>.Default
        },
        {
            ArrayEqualityComparer<T>.Create(CustomEqualityComparer<T>.Default),
            CustomEqualityComparer<T>.Default
        },
    };

    public static TheoryData<CaseParamOfArray<T>, CaseParamOfArray<T>> InputsAreEqualCases()
        =>
        MapEqualsCases(CaseSources.EqualArrays<T>());

    public static TheoryData<CaseParamOfArray<T>, CaseParamOfArray<T>> InputsAreNotEqualCases()
        =>
        MapEqualsCases(CaseSources.NotEqualArrays<T>());

    private static ArrayEqualityComparer<T> BuildComparer()
        =>
        ArrayEqualityComparer<T>.Create(CustomEqualityComparer<T>.Default);

    private static TheoryData<CaseParamOfArray<T>, CaseParamOfArray<T>> MapEqualsCases(
        IEnumerable<(T[]? X, T[]? Y)> cases)
    {
        var result = new TheoryData<CaseParamOfArray<T>, CaseParamOfArray<T>>();
        foreach (var (X, Y) in cases)
        {
            result.Add(new(X), new(Y));
        }
        return result;
    }
}
