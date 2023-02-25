using System;
using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ReadOnlyListEqualityComparer;

public sealed class EqualityComparerTestsFactory
{
    private static Type ComparerType => typeof(ReadOnlyListEqualityComparer<object>);

    [Theory]
    [MemberData(nameof(Test_Factory_ExpectItemComparer_Cases))]
    public void Test_Factory_ExpectItemComparer(ReadOnlyListEqualityComparer<object> comparer, object expectedItemComparer)
        =>
        FactoryTestHelper.AssertItemComparerMatch(ComparerType, comparer, expectedItemComparer);

    public static IEnumerable<object[]> Test_Factory_ExpectItemComparer_Cases()
    {
        yield return new object[]
        {
            ReadOnlyListEqualityComparer<object>.Default,
            EqualityComparer<object>.Default
        };
        yield return new object[]
        {
            ReadOnlyListEqualityComparer<object>.Create(),
            EqualityComparer<object>.Default
        };
        yield return new object[]
        {
            ReadOnlyListEqualityComparer<object>.Create(null),
            EqualityComparer<object>.Default
        };
        yield return new object[]
        {
            ReadOnlyListEqualityComparer<object>.Create(EqualityComparer<object>.Default),
            EqualityComparer<object>.Default
        };
        yield return new object[]
        {
            ReadOnlyListEqualityComparer<object>.Create(CustomEqualityComparer<object>.Default),
            CustomEqualityComparer<object>.Default
        };
    }
}
