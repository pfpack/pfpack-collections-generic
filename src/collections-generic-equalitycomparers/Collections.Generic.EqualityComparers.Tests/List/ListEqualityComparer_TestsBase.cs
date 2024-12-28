using System.Collections.Generic;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public abstract class ListEqualityComparer_TestsBase<T>
{
    [Theory]
    [MemberData(nameof(Test_Factory_ExpectItemComparer_Cases))]
    public static void Test_Factory_ExpectItemComparer(ListEqualityComparer<T> comparer, IEqualityComparer<T> expected)
        =>
        FactoryAssert.AssertItemComparer(comparer, expected);

    public static TheoryData<ListEqualityComparer<T>, IEqualityComparer<T>> Test_Factory_ExpectItemComparer_Cases => new()
    {
        {
            ListEqualityComparer<T>.Default,
            EqualityComparer<T>.Default
        },
        {
            ListEqualityComparer<T>.Create(),
            EqualityComparer<T>.Default
        },
        {
            ListEqualityComparer<T>.Create(null),
            EqualityComparer<T>.Default
        },
        {
            ListEqualityComparer<T>.Create(EqualityComparer<T>.Default),
            EqualityComparer<T>.Default
        },
        {
            ListEqualityComparer<T>.Create(CustomEqualityComparer<T>.Default),
            CustomEqualityComparer<T>.Default
        },
    };

    protected static ListEqualityComparer<T> BuildComparer()
        =>
        ListEqualityComparer<T>.Create(CustomEqualityComparer<T>.Default);
}
