using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public abstract class ReadOnlyListEqualityComparer_TestsBase<T>
{
    [Theory]
    [MemberData(nameof(Test_Factory_ExpectItemComparer_Cases))]
    public static void Test_Factory_ExpectItemComparer(ReadOnlyListEqualityComparer<T> comparer, IEqualityComparer<T> expected)
       =>
       FactoryAssert.AssertItemComparer(comparer, expected);

    [Fact]
    public static void Test_GetHashCode_InputIsNull_ExpectZero()
    {
        var comparer = BuildComparer();
        IReadOnlyList<T>? nullObj = null;
        var actual = comparer.GetHashCode(nullObj);
        Assert.StrictEqual(0, actual);
    }

    [Theory]
    [MemberData(nameof(InputsAreEqualCases))]
    public static void Test_GetHashCode_InputsAreEqual_ExpectHashCodesAreEqual(CaseParamOfIReadOnlyList<T> input1, CaseParamOfIReadOnlyList<T> input2)
    {
        var comparer = BuildComparer();
        var hashCode1 = comparer.GetHashCode(input1.Items);
        var hashCode2 = comparer.GetHashCode(input2.Items);
        Assert.StrictEqual(hashCode1, hashCode2);
    }

    [Theory]
    [MemberData(nameof(InputsAreEqualCases))]
    public static void Test_Equals_InputsAreEqual_ExpectTrue(CaseParamOfIReadOnlyList<T> input1, CaseParamOfIReadOnlyList<T> input2)
    {
        var comparer = BuildComparer();
        var actualEquals = comparer.Equals(input1.Items, input2.Items);
        Assert.True(actualEquals);
    }

    [Theory]
    [MemberData(nameof(InputsAreNotEqualCases))]
    public static void Test_Equals_InputsAreNotEqual_ExpectTrue(CaseParamOfIReadOnlyList<T> input1, CaseParamOfIReadOnlyList<T> input2)
    {
        var comparer = BuildComparer();
        var actualEquals = comparer.Equals(input1.Items, input2.Items);
        Assert.False(actualEquals);
    }

    public static TheoryData<ReadOnlyListEqualityComparer<T>, IEqualityComparer<T>> Test_Factory_ExpectItemComparer_Cases => new()
    {
        {
            ReadOnlyListEqualityComparer<T>.Default,
            EqualityComparer<T>.Default
        },
        {
            ReadOnlyListEqualityComparer<T>.Create(),
            EqualityComparer<T>.Default
        },
        {
            ReadOnlyListEqualityComparer<T>.Create(null),
            EqualityComparer<T>.Default
        },
        {
            ReadOnlyListEqualityComparer<T>.Create(EqualityComparer<T>.Default),
            EqualityComparer<T>.Default
        },
        {
            ReadOnlyListEqualityComparer<T>.Create(CustomEqualityComparer<T>.Default),
            CustomEqualityComparer<T>.Default
        },
    };

    public static TheoryData<CaseParamOfIReadOnlyList<T>, CaseParamOfIReadOnlyList<T>> InputsAreEqualCases()
        =>
        MapEqualsCases(CaseSources.EqualArrays<T>());

    public static TheoryData<CaseParamOfIReadOnlyList<T>, CaseParamOfIReadOnlyList<T>> InputsAreNotEqualCases()
        =>
        MapEqualsCases(CaseSources.NotEqualArrays<T>());

    private static ReadOnlyListEqualityComparer<T> BuildComparer()
        =>
        ReadOnlyListEqualityComparer<T>.Create(CustomEqualityComparer<T>.Default);

    private static TheoryData<CaseParamOfIReadOnlyList<T>, CaseParamOfIReadOnlyList<T>> MapEqualsCases(
        IEnumerable<(T[]? X, T[]? Y)> cases)
    {
        var result = new TheoryData<CaseParamOfIReadOnlyList<T>, CaseParamOfIReadOnlyList<T>>();
        foreach (var (X, Y) in cases)
        {
            var (x, y) = CaseParamsMapper.MapToOfIReadOnlyList(X, Y);
            result.Add(x, y);
        }
        return result;
    }
}
