using System.Collections.Generic;
using System.Collections.Immutable;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ImmutableArrayEqualityComparer_Nullable;

public static class EqualityComparerTestsGeneral
{
    private static readonly ImmutableArrayEqualityComparer<object> comparer
        = ImmutableArrayEqualityComparer<object>.Create(CustomEqualityComparer<object>.Default);

    [Fact]
    public static void Test_GetHashCode_SourceIsNull_ExpectZero()
    {
        ImmutableArray<object>? nullObj = default;
        var actual = comparer.GetHashCode(nullObj);
        Assert.StrictEqual(0, actual);
    }

    [Fact]
    public static void Test_GetHashCode_SourceIsWrappedDefault_ExpectZero()
    {
        var wrappedDefaultObj = new ImmutableArray<object>?(default);
        var actual = comparer.GetHashCode(wrappedDefaultObj);
        Assert.StrictEqual(0, actual);
    }
}
