using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ListEqualityComparer_IList;

public sealed class EqualityComparerTestsGeneral
{
    private readonly ListEqualityComparer<object> comparer
        = ListEqualityComparer<object>.Create(CustomEqualityComparer<object>.Default);

    [Fact]
    public void Test_GetHashCode_SourceIsNull_ExpectZero()
    {
        IList<object>? nullObj = null;
        var actual = comparer.GetHashCode(nullObj);
        Assert.Equal(0, actual);
    }
}
