using System.Collections.Generic;
using System.Collections.Immutable;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public abstract class ImmutableArrayEqualityComparer_Nullable_TestsBase<T> : ImmutableArrayEqualityComparer_TestsBase<T>
{
    [Fact]
    public static void Test_GetHashCode_SourceIsNull_ExpectZero()
    {
        var comparer = BuildComparer();
        ImmutableArray<T>? nullObj = null;
        var actual = comparer.GetHashCode(nullObj);
        Assert.StrictEqual(0, actual);
    }

    [Fact]
    public static void Test_GetHashCode_SourceIsWrappedDefault_ExpectZero()
    {
        var comparer = BuildComparer();
        var actual = comparer.GetHashCode(new ImmutableArray<T>?(default));
        Assert.StrictEqual(0, actual);
    }

    protected static TheoryData<CaseParamOfImmutableArrayNullable<T>, CaseParamOfImmutableArrayNullable<T>> MapEqualsCases(
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
