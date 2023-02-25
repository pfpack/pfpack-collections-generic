using System;
using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ImmutableArrayEqualityComparer;

public sealed class EqualityComparerTestsFactory
{
    private static Type ComparerType => typeof(ImmutableArrayEqualityComparer<object>);

    [Theory]
    [MemberData(nameof(Test_Factory_ExpectItemComparer_Cases))]
    public void Test_Factory_ExpectItemComparer(ImmutableArrayEqualityComparer<object> comparer, object expectedItemComparer)
        =>
        FactoryTestHelper.AssertItemComparerMatch(ComparerType, comparer, expectedItemComparer);

    public static IEnumerable<object[]> Test_Factory_ExpectItemComparer_Cases()
    {
        yield return new object[]
        {
            ImmutableArrayEqualityComparer<object>.Default,
            EqualityComparer<object>.Default
        };
        yield return new object[]
        {
            ImmutableArrayEqualityComparer<object>.Create(),
            EqualityComparer<object>.Default
        };
        yield return new object[]
        {
            ImmutableArrayEqualityComparer<object>.Create(null),
            EqualityComparer<object>.Default
        };
        yield return new object[]
        {
            ImmutableArrayEqualityComparer<object>.Create(EqualityComparer<object>.Default),
            EqualityComparer<object>.Default
        };
        yield return new object[]
        {
            ImmutableArrayEqualityComparer<object>.Create(CustomEqualityComparer<object>.Default),
            CustomEqualityComparer<object>.Default
        };
    }
}
