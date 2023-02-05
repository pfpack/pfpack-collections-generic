using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public abstract class ArrayEqualityComparerTestsBase<T>
{
    protected readonly ArrayEqualityComparer<T> comparer;

    protected ArrayEqualityComparerTestsBase(Func<ArrayEqualityComparer<T>> comparerFactory)
    {
        comparer = comparerFactory.Invoke();
        Debug.Assert(comparer is not null);
    }

    [Fact]
    public void Test_GetHashCode_SourceIsNull_ExpectZero()
    {
        var actual = comparer.GetHashCode(null);
        Assert.Equal(0, actual);
    }
}
