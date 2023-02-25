using System;
using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ArrayEqualityComparer;

public sealed class EqualityComparerTestsFactory
{
    private static Type ComparerType => typeof(ArrayEqualityComparer<object>);

    [Theory]
    [MemberData(nameof(Test_Factory_ExpectItemComparer_Cases))]
    public void Test_Factory_ExpectItemComparer(ArrayEqualityComparer<object> comparer, object expectedItemComparer)
        =>
        FactoryTestHelper.AssertItemComparerMatch(ComparerType, comparer, expectedItemComparer);

    public static IEnumerable<object[]> Test_Factory_ExpectItemComparer_Cases()
    {
        yield return new object[]
        {
            ArrayEqualityComparer<object>.Default,
            EqualityComparer<object>.Default
        };
        yield return new object[]
        {
            ArrayEqualityComparer<object>.Create(),
            EqualityComparer<object>.Default
        };
        yield return new object[]
        {
            ArrayEqualityComparer<object>.Create(null),
            EqualityComparer<object>.Default
        };
        yield return new object[]
        {
            ArrayEqualityComparer<object>.Create(EqualityComparer<object>.Default),
            EqualityComparer<object>.Default
        };
        yield return new object[]
        {
            ArrayEqualityComparer<object>.Create(CustomEqualityComparer<object>.Default),
            CustomEqualityComparer<object>.Default
        };
    }
}
