using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

internal sealed class CustomEqualityComparer<T> : IEqualityComparer<T>
{
    public bool Equals(T? x, T? y)
        =>
        EqualityComparer<T>.Default.Equals(x, y);

    public int GetHashCode([DisallowNull] T obj)
        =>
        EqualityComparer<T>.Default.GetHashCode(obj);

    public static CustomEqualityComparer<T> Default { get; } = new();
}
