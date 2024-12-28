using System.Collections.Generic;
using System.Collections.Immutable;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public abstract class ImmutableArrayEqualityComparer_Nonnull_TestsBase<T> : ImmutableArrayEqualityComparer_TestsBase<T>
{
    [Fact]
    public static void Test_GetHashCode_SourceIsDefault_ExpectZero()
    {
        var comparer = BuildComparer();
        ImmutableArray<T> nullObj = default;
        var actual = comparer.GetHashCode(nullObj);
        Assert.StrictEqual(0, actual);
    }

    protected static TheoryData<CaseParamOfImmutableArray<T>, CaseParamOfImmutableArray<T>> MapEqualsCases(
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
