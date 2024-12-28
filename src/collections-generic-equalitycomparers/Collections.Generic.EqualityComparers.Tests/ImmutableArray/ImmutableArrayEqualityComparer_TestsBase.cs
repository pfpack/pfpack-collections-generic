using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public abstract class ImmutableArrayEqualityComparer_TestsBase<T>
{
    [Theory]
    [MemberData(nameof(Test_Factory_ExpectItemComparer_Cases))]
    public static void Test_Factory_ExpectItemComparer(ImmutableArrayEqualityComparer<T> comparer, IEqualityComparer<T> expectedItemComparer)
        =>
        FactoryAssert.AssertItemComparer(comparer, expectedItemComparer);

    public static TheoryData<ImmutableArrayEqualityComparer<T>, IEqualityComparer<T>> Test_Factory_ExpectItemComparer_Cases => new()
    {
        {
            ImmutableArrayEqualityComparer<T>.Default,
            EqualityComparer<T>.Default
        },
        {
            ImmutableArrayEqualityComparer<T>.Create(),
            EqualityComparer<T>.Default
        },
        {
            ImmutableArrayEqualityComparer<T>.Create(null),
            EqualityComparer<T>.Default
        },
        {
            ImmutableArrayEqualityComparer<T>.Create(EqualityComparer<T>.Default),
            EqualityComparer<T>.Default
        },
        {
            ImmutableArrayEqualityComparer<T>.Create(CustomEqualityComparer<T>.Default),
            CustomEqualityComparer<T>.Default
        },
    };

    protected static ImmutableArrayEqualityComparer<T> BuildComparer()
        =>
        ImmutableArrayEqualityComparer<T>.Create(CustomEqualityComparer<T>.Default);
}
