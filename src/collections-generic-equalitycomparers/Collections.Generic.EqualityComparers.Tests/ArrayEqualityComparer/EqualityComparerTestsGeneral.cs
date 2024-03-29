﻿using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ArrayEqualityComparer;

public static class EqualityComparerTestsGeneral
{
    private static readonly ArrayEqualityComparer<object> comparer
        = ArrayEqualityComparer<object>.Create(CustomEqualityComparer<object>.Default);

    [Fact]
    public static void Test_GetHashCode_SourceIsNull_ExpectZero()
    {
        object[]? nullObj = null;
        var actual = comparer.GetHashCode(nullObj);
        Assert.StrictEqual(0, actual);
    }
}
