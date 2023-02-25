using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ListEqualityComparer.List;

public abstract class EqualityComparerTestsBase_Ref : EqualityComparerTestsBase<string?>
{
    protected EqualityComparerTestsBase_Ref(Func<ListEqualityComparer<string?>> comparerFactory)
        : base(comparerFactory)
    {
    }

    [Theory]
    [MemberData(nameof(SourceAreEqualCases))]
    public void Test_GetHashCode_SourceAreEqual_ExpectHashCodesAreEqual(CaseParamOfList<string?> source1, CaseParamOfList<string?> source2)
    {
        var hashCode1 = comparer.GetHashCode(source1.Items);
        var hashCode2 = comparer.GetHashCode(source2.Items);
        Assert.StrictEqual(hashCode1, hashCode2);
    }

    [Theory]
    [MemberData(nameof(SourceAreEqualCases))]
    public void Test_Equals_SourceAreEqual_ExpectTrue(CaseParamOfList<string?> source1, CaseParamOfList<string?> source2)
    {
        var actualEquals = comparer.Equals(source1.Items, source2.Items);
        Assert.True(actualEquals);
    }

    [Theory]
    [MemberData(nameof(SourceAreNotEqualCases))]
    public void Test_Equals_SourceAreNotEqual_ExpectTrue(CaseParamOfList<string?> source1, CaseParamOfList<string?> source2)
    {
        var actualEquals = comparer.Equals(source1.Items, source2.Items);
        Assert.False(actualEquals);
    }

    public static IEnumerable<object[]> SourceAreEqualCases()
        =>
        CaseSourcesArrayRef.SourceAreEqualCases()
        .Select(@case => CaseMapper.MapToOfList(@case));

    public static IEnumerable<object[]> SourceAreNotEqualCases()
        =>
        CaseSourcesArrayRef.SourceAreNotEqualCases()
        .Select(@case => CaseMapper.MapToOfList(@case));
}
