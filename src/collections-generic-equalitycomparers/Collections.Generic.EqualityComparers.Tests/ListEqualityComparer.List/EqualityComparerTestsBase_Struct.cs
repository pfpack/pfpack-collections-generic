using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ListEqualityComparer.List;

public abstract class EqualityComparerTestsBase_Struct : EqualityComparerTestsBase<int?>
{
    protected EqualityComparerTestsBase_Struct(Func<ListEqualityComparer<int?>> comparerFactory)
        : base(comparerFactory)
    {
    }

    [Theory]
    [MemberData(nameof(SourceAreEqualCases))]
    public void Test_GetHashCode_SourceAreEqual_ExpectHashCodesAreEqual(CaseParamOfList<int?> source1, CaseParamOfList<int?> source2)
    {
        var hashCode1 = comparer.GetHashCode(source1.Items);
        var hashCode2 = comparer.GetHashCode(source2.Items);
        Assert.StrictEqual(hashCode1, hashCode2);
    }

    [Theory]
    [MemberData(nameof(SourceAreEqualCases))]
    public void Test_Equals_SourceAreEqual_ExpectTrue(CaseParamOfList<int?> source1, CaseParamOfList<int?> source2)
    {
        var actualEquals = comparer.Equals(source1.Items, source2.Items);
        Assert.True(actualEquals);
    }

    [Theory]
    [MemberData(nameof(SourceAreNotEqualCases))]
    public void Test_Equals_SourceAreNotEqual_ExpectTrue(CaseParamOfList<int?> source1, CaseParamOfList<int?> source2)
    {
        var actualEquals = comparer.Equals(source1.Items, source2.Items);
        Assert.False(actualEquals);
    }

    public static IEnumerable<object[]> SourceAreEqualCases()
        =>
        CaseSourcesArrayStruct.SourceAreEqualCases()
        .Select(@case => CaseMapper.MapToOfList(@case));

    public static IEnumerable<object[]> SourceAreNotEqualCases()
        =>
        CaseSourcesArrayStruct.SourceAreNotEqualCases()
        .Select(@case => CaseMapper.MapToOfList(@case));
}
