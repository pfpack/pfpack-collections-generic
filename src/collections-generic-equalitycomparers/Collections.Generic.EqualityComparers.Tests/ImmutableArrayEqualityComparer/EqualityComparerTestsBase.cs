﻿using System;
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
    public void Test_GetHashCode_SourceIsNull_ExpectZero()
    {
        ImmutableArray<T> nullObj = default; 
        var actual = comparer.GetHashCode(nullObj);
        Assert.Equal(0, actual);
    }
}
