using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ListEqualityComparer.IList;

public abstract class EqualityComparerTestsBase<T>
{
    protected readonly ListEqualityComparer<T> comparer;

    protected EqualityComparerTestsBase(Func<ListEqualityComparer<T>> comparerFactory)
    {
        comparer = comparerFactory.Invoke();
        Debug.Assert(comparer is not null);
    }

    [Fact]
    public void Test_GetHashCode_SourceIsNull_ExpectZero()
    {
        var actual = comparer.GetHashCode((IList<T>?)null);
        Assert.Equal(0, actual);
    }
}
