using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ImmutableArrayEqualityComparer;

public abstract class EqualityComparerTestsBase<T>
{
    protected readonly ImmutableArrayEqualityComparer<T> comparer;

    protected EqualityComparerTestsBase(Func<ImmutableArrayEqualityComparer<T>> comparerFactory)
    {
        comparer = comparerFactory.Invoke();
        Debug.Assert(comparer is not null);
    }

    [Fact]
    public void Test_GetHashCode_SourceIsDefault_ExpectZero()
    {
        ImmutableArray<T> defaultObj = default;
        var actual = comparer.GetHashCode(defaultObj);
        Assert.Equal(0, actual);
    }
}
