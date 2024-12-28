using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

internal static class FactoryAssert
{
    internal static void AssertItemComparer<TCollectionComparer, T>(
        TCollectionComparer comparer,
        IEqualityComparer<T> expected)
    {
        var field = typeof(TCollectionComparer).GetField("comparer", BindingFlags.Instance | BindingFlags.NonPublic);

        Assert.NotNull(field);
        Assert.True(field.IsPrivate);
        Assert.True(field.IsInitOnly);

        var actual = field.GetValue(comparer);
        Assert.Same(actual, expected);
    }
}
