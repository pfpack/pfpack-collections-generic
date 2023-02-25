using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ReadOnlyListEqualityComparer;

public sealed class EqualityComparerTestsGeneral
{
    private readonly ReadOnlyListEqualityComparer<object> comparer
        = ReadOnlyListEqualityComparer<object>.Create(CustomEqualityComparer<object>.Default);

    [Fact]
    public void Test_GetHashCode_SourceIsNull_ExpectZero()
    {
        IReadOnlyList<object>? nullObj = null;
        var actual = comparer.GetHashCode(nullObj);
        Assert.Equal(0, actual);
    }
}
