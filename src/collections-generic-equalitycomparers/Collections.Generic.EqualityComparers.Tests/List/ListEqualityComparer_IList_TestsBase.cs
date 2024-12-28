using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public abstract class ListEqualityComparer_IList_TestsBase<T> : ListEqualityComparer_TestsBase<T>
{
    [Fact]
    public static void Test_GetHashCode_SourceIsNull_ExpectZero()
    {
        var comparer = BuildComparer();
        IList<T>? nullObj = null;
        var actual = comparer.GetHashCode(nullObj);
        Assert.StrictEqual(0, actual);
    }

    protected static TheoryData<CaseParamOfIList<T>, CaseParamOfIList<T>> MapEqualsCases(
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
