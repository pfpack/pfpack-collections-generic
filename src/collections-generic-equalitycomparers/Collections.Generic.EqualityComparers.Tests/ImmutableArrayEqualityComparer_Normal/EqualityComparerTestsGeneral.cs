﻿using System.Collections.Generic;
using System.Collections.Immutable;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ImmutableArrayEqualityComparer_Normal;

public static class EqualityComparerTestsGeneral
{
    private static readonly ImmutableArrayEqualityComparer<object> comparer
        = ImmutableArrayEqualityComparer<object>.Create(CustomEqualityComparer<object>.Default);

    [Fact]
    public static void Test_GetHashCode_SourceIsDefault_ExpectZero()
    {
        ImmutableArray<object> defaultObj = default;
        var actual = comparer.GetHashCode(defaultObj);
        Assert.StrictEqual(0, actual);
    }
}
