using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public abstract class ArrayEqualityComparer_TestsBase<T>
{
    [Theory]
    [MemberData(nameof(Test_Factory_ExpectItemComparer_Cases))]
    public static void Test_Factory_ExpectItemComparer(ArrayEqualityComparer<T> comparer, IEqualityComparer<T> expectedItemComparer)
        =>
        FactoryAssert.AssertItemComparer(comparer, expectedItemComparer);

    [Fact]
    public static void Test_GetHashCode_SourceIsNull_ExpectZero()
    {
        var comparer = BuildComparer();
        T[]? nullObj = null;
        var actual = comparer.GetHashCode(nullObj);
        Assert.StrictEqual(0, actual);
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

    protected static ArrayEqualityComparer<T> BuildComparer()
        =>
        ArrayEqualityComparer<T>.Create(CustomEqualityComparer<T>.Default);

    protected static TheoryData<CaseParamOfArray<T>, CaseParamOfArray<T>> MapEqualsCases(
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
