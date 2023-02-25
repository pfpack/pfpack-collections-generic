using System.Collections;
using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

internal sealed class CustomReadOnlyList<T> : IReadOnlyList<T>
{
    private readonly T[] items;

    public CustomReadOnlyList(params T[] items) => this.items = items;

    public static CustomReadOnlyList<T> Empty { get; } = new();

    public int Count => items.Length;

    public T this[int index] => items[index];

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in items) yield return item;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
