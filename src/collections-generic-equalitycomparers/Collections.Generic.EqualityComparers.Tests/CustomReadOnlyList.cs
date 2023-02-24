using System.Collections;
using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

internal static class CustomReadOnlyList
{
    internal static CustomReadOnlyList<T> Create<T>(params T[] items) => new(items);
}

internal sealed class CustomReadOnlyList<T> : IReadOnlyList<T>
{
    private static class InnerEmpty
    {
        internal static readonly CustomReadOnlyList<T> Value = new();
    }

    internal static CustomReadOnlyList<T> Empty => InnerEmpty.Value;

    private readonly T[] items;

    internal CustomReadOnlyList(params T[] items) => this.items = items;

    public int Count => items.Length;

    public T this[int index] => items[index];

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in items) yield return item;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
