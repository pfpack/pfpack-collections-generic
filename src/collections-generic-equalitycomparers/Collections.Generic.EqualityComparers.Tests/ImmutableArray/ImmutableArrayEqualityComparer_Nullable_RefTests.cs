using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class ImmutableArrayEqualityComparer_Nullable_RefTests : ImmutableArrayEqualityComparer_Nullable_TestsBase<string?>
{
    [Theory]
    [MemberData(nameof(SourceAreEqualCases))]
    public static void Test_GetHashCode_SourceAreEqual_ExpectHashCodesAreEqual(CaseParamOfImmutableArrayNullable<string?> source1, CaseParamOfImmutableArrayNullable<string?> source2)
    {
        var comparer = BuildComparer();
        var hashCode1 = comparer.GetHashCode(source1.Items);
        var hashCode2 = comparer.GetHashCode(source2.Items);
        Assert.StrictEqual(hashCode1, hashCode2);
    }

    [Theory]
    [MemberData(nameof(SourceAreEqualCases))]
    public static void Test_Equals_SourceAreEqual_ExpectTrue(CaseParamOfImmutableArrayNullable<string?> source1, CaseParamOfImmutableArrayNullable<string?> source2)
    {
        var comparer = BuildComparer();
        var actualEquals = comparer.Equals(source1.Items, source2.Items);
        Assert.True(actualEquals);
    }

    [Theory]
    [MemberData(nameof(SourceAreNotEqualCases))]
    public static void Test_Equals_SourceAreNotEqual_ExpectTrue(CaseParamOfImmutableArrayNullable<string?> source1, CaseParamOfImmutableArrayNullable<string?> source2)
    {
        var comparer = BuildComparer();
        var actualEquals = comparer.Equals(source1.Items, source2.Items);
        Assert.False(actualEquals);
    }

    public static TheoryData<CaseParamOfImmutableArrayNullable<string?>, CaseParamOfImmutableArrayNullable<string?>> SourceAreEqualCases()
        =>
        MapEqualsCases(CaseSourcesArrayRef.SourceAreEqualCases());

    public static TheoryData<CaseParamOfImmutableArrayNullable<string?>, CaseParamOfImmutableArrayNullable<string?>> SourceAreNotEqualCases()
        =>
        MapEqualsCases(CaseSourcesArrayRef.SourceAreNotEqualCases());
}
