﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ReadOnlyListEqualityComparer;

public abstract class EqualityComparerTestsBase<T>
{
    protected readonly ReadOnlyListEqualityComparer<T> comparer;

    protected EqualityComparerTestsBase(Func<ReadOnlyListEqualityComparer<T>> comparerFactory)
    {
        comparer = comparerFactory.Invoke();
        Debug.Assert(comparer is not null);
    }

    [Fact]
    public void Test_GetHashCode_SourceIsNull_ExpectZero()
    {
        IReadOnlyList<T>? nullObj = null;
        var actual = comparer.GetHashCode(nullObj);
        Assert.Equal(0, actual);
    }
}
