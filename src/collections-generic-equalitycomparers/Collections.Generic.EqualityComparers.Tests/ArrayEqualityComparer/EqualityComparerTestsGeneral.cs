using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ArrayEqualityComparer;

public sealed class EqualityComparerTestsGeneral
{
    private readonly ArrayEqualityComparer<object> comparer
        = ArrayEqualityComparer<object>.Create(CustomEqualityComparer<object>.Default);

    [Fact]
    public void Test_GetHashCode_SourceIsNull_ExpectZero()
    {
        object[]? nullObj = null;
        var actual = comparer.GetHashCode(nullObj);
        Assert.Equal(0, actual);
    }
}
