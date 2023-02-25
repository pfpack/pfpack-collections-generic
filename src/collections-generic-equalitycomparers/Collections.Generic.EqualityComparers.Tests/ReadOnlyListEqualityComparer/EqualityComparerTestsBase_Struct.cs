﻿using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ReadOnlyListEqualityComparer;

public sealed class EqualityComparerTestsBase_Struct
{
    private readonly ReadOnlyListEqualityComparer<int?> comparer
        = ReadOnlyListEqualityComparer<int?>.Create(CustomEqualityComparer<int?>.Default);

    [Theory]
    [MemberData(nameof(SourceAreEqualCases))]
    public void Test_GetHashCode_SourceAreEqual_ExpectHashCodesAreEqual(CaseParamOfIReadOnlyList<int?> source1, CaseParamOfIReadOnlyList<int?> source2)
    {
        var hashCode1 = comparer.GetHashCode(source1.Items);
        var hashCode2 = comparer.GetHashCode(source2.Items);
        Assert.StrictEqual(hashCode1, hashCode2);
    }

    [Theory]
    [MemberData(nameof(SourceAreEqualCases))]
    public void Test_Equals_SourceAreEqual_ExpectTrue(CaseParamOfIReadOnlyList<int?> source1, CaseParamOfIReadOnlyList<int?> source2)
    {
        var actualEquals = comparer.Equals(source1.Items, source2.Items);
        Assert.True(actualEquals);
    }

    [Theory]
    [MemberData(nameof(SourceAreNotEqualCases))]
    public void Test_Equals_SourceAreNotEqual_ExpectTrue(CaseParamOfIReadOnlyList<int?> source1, CaseParamOfIReadOnlyList<int?> source2)
    {
        var actualEquals = comparer.Equals(source1.Items, source2.Items);
        Assert.False(actualEquals);
    }

    public static IEnumerable<object[]> SourceAreEqualCases()
        =>
        CaseSourcesArrayStruct.SourceAreEqualCases()
        .Select(@case => CaseMapper.MapToOfIReadOnlyList(@case));

    public static IEnumerable<object[]> SourceAreNotEqualCases()
        =>
        CaseSourcesArrayStruct.SourceAreNotEqualCases()
        .Select(@case => CaseMapper.MapToOfIReadOnlyList(@case));
}
