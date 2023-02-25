using System;
using System.Reflection;
using Xunit;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

internal static class FactoryTestHelper
{
    internal static void AssertItemComparerMatch<TCollectionComparer>(
        Type type,
        TCollectionComparer collectionComparer,
        object itemComparerMatch)
    {
        var field = type.GetField("comparer", BindingFlags.Instance | BindingFlags.NonPublic);

        Assert.NotNull(field);
        Assert.True(field.IsPrivate);

        var itemComparer = field.GetValue(collectionComparer);
        Assert.True(ReferenceEquals(itemComparer, itemComparerMatch));
    }
}
