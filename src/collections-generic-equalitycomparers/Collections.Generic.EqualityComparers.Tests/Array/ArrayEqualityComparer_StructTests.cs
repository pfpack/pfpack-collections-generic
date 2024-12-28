using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class ArrayEqualityComparer_StructTests : ArrayEqualityComparer_TestsBase<int?>
{
    [Theory]
    [MemberData(nameof(SourceAreEqualCases))]
    public static void Test_GetHashCode_SourceAreEqual_ExpectHashCodesAreEqual(CaseParamOfArray<int?> source1, CaseParamOfArray<int?> source2)
    {
        var comparer = BuildComparer();
        var hashCode1 = comparer.GetHashCode(source1.Items);
        var hashCode2 = comparer.GetHashCode(source2.Items);
        Assert.StrictEqual(hashCode1, hashCode2);
    }

    [Theory]
    [MemberData(nameof(SourceAreEqualCases))]
    public static void Test_Equals_SourceAreEqual_ExpectTrue(CaseParamOfArray<int?> source1, CaseParamOfArray<int?> source2)
    {
        var comparer = BuildComparer();
        var actualEquals = comparer.Equals(source1.Items, source2.Items);
        Assert.True(actualEquals);
    }

    [Theory]
    [MemberData(nameof(SourceAreNotEqualCases))]
    public static void Test_Equals_SourceAreNotEqual_ExpectTrue(CaseParamOfArray<int?> source1, CaseParamOfArray<int?> source2)
    {
        var comparer = BuildComparer();
        var actualEquals = comparer.Equals(source1.Items, source2.Items);
        Assert.False(actualEquals);
    }

    public static TheoryData<CaseParamOfArray<int?>, CaseParamOfArray<int?>> SourceAreEqualCases()
        =>
        MapEqualsCases(CaseSourcesArrayStruct.SourceAreEqualCases());

    public static TheoryData<CaseParamOfArray<int?>, CaseParamOfArray<int?>> SourceAreNotEqualCases()
        =>
        MapEqualsCases(CaseSourcesArrayStruct.SourceAreNotEqualCases());
}
