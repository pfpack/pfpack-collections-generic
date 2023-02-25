using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ArrayEqualityComparer;

public sealed class EqualityComparerTestsBase_Ref
{
    private readonly ArrayEqualityComparer<string?> comparer
        = ArrayEqualityComparer<string?>.Create(CustomEqualityComparer<string?>.Default);

    [Theory]
    [MemberData(nameof(SourceAreEqualCases))]
    public void Test_GetHashCode_SourceAreEqual_ExpectHashCodesAreEqual(CaseParamOfArray<string?> source1, CaseParamOfArray<string?> source2)
    {
        var hashCode1 = comparer.GetHashCode(source1.Items);
        var hashCode2 = comparer.GetHashCode(source2.Items);
        Assert.StrictEqual(hashCode1, hashCode2);
    }

    [Theory]
    [MemberData(nameof(SourceAreEqualCases))]
    public void Test_Equals_SourceAreEqual_ExpectTrue(CaseParamOfArray<string?> source1, CaseParamOfArray<string?> source2)
    {
        var actualEquals = comparer.Equals(source1.Items, source2.Items);
        Assert.True(actualEquals);
    }

    [Theory]
    [MemberData(nameof(SourceAreNotEqualCases))]
    public void Test_Equals_SourceAreNotEqual_ExpectTrue(CaseParamOfArray<string?> source1, CaseParamOfArray<string?> source2)
    {
        var actualEquals = comparer.Equals(source1.Items, source2.Items);
        Assert.False(actualEquals);
    }

    public static IEnumerable<object[]> SourceAreEqualCases()
        =>
        CaseSourcesArrayRef.SourceAreEqualCases();

    public static IEnumerable<object[]> SourceAreNotEqualCases()
        =>
        CaseSourcesArrayRef.SourceAreNotEqualCases();
}
