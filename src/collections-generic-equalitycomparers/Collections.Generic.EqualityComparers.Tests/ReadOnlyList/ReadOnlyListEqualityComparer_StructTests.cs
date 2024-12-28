using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class ReadOnlyListEqualityComparer_StructTests : ReadOnlyListEqualityComparer_TestsBase<int?>
{
    [Theory]
    [MemberData(nameof(SourceAreEqualCases))]
    public static void Test_GetHashCode_SourceAreEqual_ExpectHashCodesAreEqual(CaseParamOfIReadOnlyList<int?> source1, CaseParamOfIReadOnlyList<int?> source2)
    {
        var comparer = BuildComparer();
        var hashCode1 = comparer.GetHashCode(source1.Items);
        var hashCode2 = comparer.GetHashCode(source2.Items);
        Assert.StrictEqual(hashCode1, hashCode2);
    }

    [Theory]
    [MemberData(nameof(SourceAreEqualCases))]
    public static void Test_Equals_SourceAreEqual_ExpectTrue(CaseParamOfIReadOnlyList<int?> source1, CaseParamOfIReadOnlyList<int?> source2)
    {
        var comparer = BuildComparer();
        var actualEquals = comparer.Equals(source1.Items, source2.Items);
        Assert.True(actualEquals);
    }

    [Theory]
    [MemberData(nameof(SourceAreNotEqualCases))]
    public static void Test_Equals_SourceAreNotEqual_ExpectTrue(CaseParamOfIReadOnlyList<int?> source1, CaseParamOfIReadOnlyList<int?> source2)
    {
        var comparer = BuildComparer();
        var actualEquals = comparer.Equals(source1.Items, source2.Items);
        Assert.False(actualEquals);
    }

    public static TheoryData<CaseParamOfIReadOnlyList<int?>, CaseParamOfIReadOnlyList<int?>> SourceAreEqualCases()
        =>
        MapEqualsCases(CaseSourcesArrayStruct.SourceAreEqualCases());

    public static TheoryData<CaseParamOfIReadOnlyList<int?>, CaseParamOfIReadOnlyList<int?>> SourceAreNotEqualCases()
        =>
        MapEqualsCases(CaseSourcesArrayStruct.SourceAreNotEqualCases());
}
