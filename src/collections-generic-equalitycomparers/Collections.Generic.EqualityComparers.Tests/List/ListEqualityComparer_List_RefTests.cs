using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class ListEqualityComparer_List_RefTests : ListEqualityComparer_List_TestsBase<string?>
{
    [Theory]
    [MemberData(nameof(SourceAreEqualCases))]
    public static void Test_GetHashCode_SourceAreEqual_ExpectHashCodesAreEqual(CaseParamOfList<string?> source1, CaseParamOfList<string?> source2)
    {
        var comparer = BuildComparer();
        var hashCode1 = comparer.GetHashCode(source1.Items);
        var hashCode2 = comparer.GetHashCode(source2.Items);
        Assert.StrictEqual(hashCode1, hashCode2);
    }

    [Theory]
    [MemberData(nameof(SourceAreEqualCases))]
    public static void Test_Equals_SourceAreEqual_ExpectTrue(CaseParamOfList<string?> source1, CaseParamOfList<string?> source2)
    {
        var comparer = BuildComparer();
        var actualEquals = comparer.Equals(source1.Items, source2.Items);
        Assert.True(actualEquals);
    }

    [Theory]
    [MemberData(nameof(SourceAreNotEqualCases))]
    public static void Test_Equals_SourceAreNotEqual_ExpectTrue(CaseParamOfList<string?> source1, CaseParamOfList<string?> source2)
    {
        var comparer = BuildComparer();
        var actualEquals = comparer.Equals(source1.Items, source2.Items);
        Assert.False(actualEquals);
    }

    public static TheoryData<CaseParamOfList<string?>, CaseParamOfList<string?>> SourceAreEqualCases()
        =>
        MapEqualsCases(CaseSourcesArrayRef.SourceAreEqualCases());

    public static TheoryData<CaseParamOfList<string?>, CaseParamOfList<string?>> SourceAreNotEqualCases()
        =>
        MapEqualsCases(CaseSourcesArrayRef.SourceAreNotEqualCases());
}
