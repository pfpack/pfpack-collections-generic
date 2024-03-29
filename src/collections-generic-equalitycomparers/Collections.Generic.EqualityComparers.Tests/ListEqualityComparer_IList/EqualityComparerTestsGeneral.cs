﻿using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ListEqualityComparer_IList;

public static class EqualityComparerTestsGeneral
{
    private static readonly ListEqualityComparer<object> comparer
        = ListEqualityComparer<object>.Create(CustomEqualityComparer<object>.Default);

    [Fact]
    public static void Test_GetHashCode_SourceIsNull_ExpectZero()
    {
        IList<object>? nullObj = null;
        var actual = comparer.GetHashCode(nullObj);
        Assert.StrictEqual(0, actual);
    }
}
