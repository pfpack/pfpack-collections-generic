using System.Collections.Generic;
using System.Collections.Immutable;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ImmutableArrayEqualityComparer_Nullable;

public sealed class EqualityComparerTestsGeneral
{
    private static readonly ImmutableArrayEqualityComparer<object> comparer
        = ImmutableArrayEqualityComparer<object>.Create(CustomEqualityComparer<object>.Default);

    [Fact]
    public void Test_GetHashCode_SourceIsNull_ExpectZero()
    {
        ImmutableArray<object>? nullObj = default;
        var actual = comparer.GetHashCode(nullObj);
        Assert.Equal(0, actual);
    }

    [Fact]
    public void Test_GetHashCode_SourceIsWrappedDefault_ExpectZero()
    {
        var wrappedDefaultObj = new ImmutableArray<object>?(default);
        var actual = comparer.GetHashCode(wrappedDefaultObj);
        Assert.Equal(0, actual);
    }
}
