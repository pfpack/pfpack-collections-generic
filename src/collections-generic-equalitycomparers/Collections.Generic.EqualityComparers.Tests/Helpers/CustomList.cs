using System;
using System.Collections;
using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

internal sealed class CustomList<T>(T[] items) : IList<T>
{
    public bool IsReadOnly => true;

    public int Count => items.Length;

    public T this[int index]
    {
        get => items[index];
        set => throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in items) yield return item;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    int IList<T>.IndexOf(T item)
        =>
        throw new NotImplementedException();

    void IList<T>.Insert(int index, T item)
        =>
        throw new NotImplementedException();

    void IList<T>.RemoveAt(int index)
        =>
        throw new NotImplementedException();

    void ICollection<T>.Add(T item)
        =>
        throw new NotImplementedException();

    void ICollection<T>.Clear()
        =>
        throw new NotImplementedException();

    bool ICollection<T>.Contains(T item)
        =>
        throw new NotImplementedException();

    void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        =>
        throw new NotImplementedException();

    bool ICollection<T>.Remove(T item)
        =>
        throw new NotImplementedException();
}
