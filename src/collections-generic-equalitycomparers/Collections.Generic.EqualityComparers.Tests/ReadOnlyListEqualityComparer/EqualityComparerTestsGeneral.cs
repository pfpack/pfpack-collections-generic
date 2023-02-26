using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ReadOnlyListEqualityComparer;

public static class EqualityComparerTestsGeneral
{
    private static readonly ReadOnlyListEqualityComparer<object> comparer
        = ReadOnlyListEqualityComparer<object>.Create(CustomEqualityComparer<object>.Default);

    [Fact]
    public static void Test_GetHashCode_SourceIsNull_ExpectZero()
    {
        IReadOnlyList<object>? nullObj = null;
        var actual = comparer.GetHashCode(nullObj);
        Assert.StrictEqual(0, actual);
    }
}
