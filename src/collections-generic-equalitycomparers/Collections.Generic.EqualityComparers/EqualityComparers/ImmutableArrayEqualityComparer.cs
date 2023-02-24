using System.Collections.Immutable;

namespace System.Collections.Generic;

public sealed class ImmutableArrayEqualityComparer<T> : IEqualityComparer<ImmutableArray<T>>, IEqualityComparer<ImmutableArray<T>?>
{
    private readonly IEqualityComparer<T> comparer;

    private ImmutableArrayEqualityComparer(IEqualityComparer<T> comparer)
        =>
        this.comparer = comparer;

    public static ImmutableArrayEqualityComparer<T> Create(IEqualityComparer<T>? comparer)
        =>
        new(comparer ?? EqualityComparer<T>.Default);

    public static ImmutableArrayEqualityComparer<T> Create()
        =>
        new(EqualityComparer<T>.Default);

    public static ImmutableArrayEqualityComparer<T> Default
        =>
        InnerDefault.Value;

    public bool Equals(ImmutableArray<T> x, ImmutableArray<T> y)
    {
        if (x.Equals(y)) // Check if the values' underlying arrays are reference equal (incl. the null case)
        {
            return true;
        }

        if (x.IsDefault || y.IsDefault) // The null case
        {
            return false;
        }

        if (x.Length != y.Length)
        {
            return false;
        }

        for (int i = 0; i < x.Length; i++)
        {
            if (comparer.Equals(x[i], y[i]))
            {
                continue;
            }
            return false;
        }

        return true;
    }

    public int GetHashCode(ImmutableArray<T> obj)
    {
        if (obj.IsDefault) // The null case
        {
            return default;
        }

        HashCode builder = new();

        for (int i = 0; i < obj.Length; i++)
        {
            var item = obj[i];
            builder.Add(item is null ? default : comparer.GetHashCode(item));
        }

        return builder.ToHashCode();
    }

    public bool Equals(ImmutableArray<T>? x, ImmutableArray<T>? y)
        =>
        Equals(x ?? default, y ?? default); // The default means null

    public int GetHashCode(ImmutableArray<T>? obj)
        =>
        GetHashCode(obj ?? default); // The default means null

    private static class InnerDefault
    {
        internal static readonly ImmutableArrayEqualityComparer<T> Value = Create();
    }
}
