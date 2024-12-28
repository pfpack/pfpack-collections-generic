using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public abstract class ListEqualityComparer_List_TestsBase<T> : ListEqualityComparer_TestsBase<T>
{
    [Fact]
    public static void Test_GetHashCode_SourceIsNull_ExpectZero()
    {
        var comparer = BuildComparer();
        List<T>? nullObj = null;
        var actual = comparer.GetHashCode(nullObj);
        Assert.StrictEqual(0, actual);
    }

    protected static TheoryData<CaseParamOfList<T>, CaseParamOfList<T>> MapEqualsCases(
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
