﻿using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ListEqualityComparer_IList;

public static class EqualityComparerTestsRef
{
    private static readonly ListEqualityComparer<string?> comparer
        = ListEqualityComparer<string?>.Create(CustomEqualityComparer<string?>.Default);

    [Theory]
    [MemberData(nameof(SourceAreEqualCases))]
    public static void Test_GetHashCode_SourceAreEqual_ExpectHashCodesAreEqual(CaseParamOfIList<string?> source1, CaseParamOfIList<string?> source2)
    {
        var hashCode1 = comparer.GetHashCode(source1.Items);
        var hashCode2 = comparer.GetHashCode(source2.Items);
        Assert.StrictEqual(hashCode1, hashCode2);
    }

    [Theory]
    [MemberData(nameof(SourceAreEqualCases))]
    public static void Test_Equals_SourceAreEqual_ExpectTrue(CaseParamOfIList<string?> source1, CaseParamOfIList<string?> source2)
    {
        var actualEquals = comparer.Equals(source1.Items, source2.Items);
        Assert.True(actualEquals);
    }

    [Theory]
    [MemberData(nameof(SourceAreNotEqualCases))]
    public static void Test_Equals_SourceAreNotEqual_ExpectTrue(CaseParamOfIList<string?> source1, CaseParamOfIList<string?> source2)
    {
        var actualEquals = comparer.Equals(source1.Items, source2.Items);
        Assert.False(actualEquals);
    }

    public static IEnumerable<object[]> SourceAreEqualCases()
        =>
        CaseSourcesArrayRef.SourceAreEqualCases()
        .Select(@case => CaseMapper.MapToOfIList(@case));

    public static IEnumerable<object[]> SourceAreNotEqualCases()
        =>
        CaseSourcesArrayRef.SourceAreNotEqualCases()
        .Select(@case => CaseMapper.MapToOfIList(@case));
}
