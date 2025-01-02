using System.Collections;
using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

internal sealed class CustomReadOnlyList<T>(T[] items) : IReadOnlyList<T>
{
    public int Count => items.Length;

    public T this[int index] => items[index];

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in items) yield return item;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
