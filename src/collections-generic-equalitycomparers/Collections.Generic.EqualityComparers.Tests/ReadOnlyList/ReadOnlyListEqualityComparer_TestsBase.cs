using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public abstract class ReadOnlyListEqualityComparer_TestsBase<T>
{
    [Theory]
    [MemberData(nameof(Test_Factory_ExpectItemComparer_Cases))]
    public static void Test_Factory_ExpectItemComparer(ReadOnlyListEqualityComparer<T> comparer, IEqualityComparer<T> expectedItemComparer)
       =>
       FactoryAssert.AssertItemComparer(comparer, expectedItemComparer);

    [Fact]
    public static void Test_GetHashCode_SourceIsNull_ExpectZero()
    {
        var comparer = BuildComparer();
        IReadOnlyList<T>? nullObj = null;
        var actual = comparer.GetHashCode(nullObj);
        Assert.StrictEqual(0, actual);
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

    protected static ReadOnlyListEqualityComparer<T> BuildComparer()
        =>
        ReadOnlyListEqualityComparer<T>.Create(CustomEqualityComparer<T>.Default);

    protected static TheoryData<CaseParamOfIReadOnlyList<T>, CaseParamOfIReadOnlyList<T>> MapEqualsCases(
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
