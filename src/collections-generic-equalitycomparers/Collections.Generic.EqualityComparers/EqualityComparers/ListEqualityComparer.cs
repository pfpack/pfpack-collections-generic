﻿namespace System.Collections.Generic;

public sealed class ListEqualityComparer<T> : IEqualityComparer<IList<T>>, IEqualityComparer<List<T>>
{
    private readonly IEqualityComparer<T> comparer;

    private ListEqualityComparer(IEqualityComparer<T> comparer)
        =>
        this.comparer = comparer;

    public static ListEqualityComparer<T> Create(IEqualityComparer<T>? comparer)
        =>
        new(comparer ?? EqualityComparer<T>.Default);

    public static ListEqualityComparer<T> Create()
        =>
        new(EqualityComparer<T>.Default);

    public static ListEqualityComparer<T> Default
        =>
        InnerDefault.Value;

    public bool Equals(IList<T>? x, IList<T>? y)
    {
        if (ReferenceEquals(x, y))
        {
            return true;
        }

        if (x is null || y is null)
        {
            return false;
        }

        if (x.Count != y.Count)
        {
            return false;
        }

        for (int i = 0; i < x.Count; i++)
        {
            if (comparer.Equals(x[i], y[i]))
            {
                continue;
            }
            return false;
        }

        return true;
    }

    public int GetHashCode(IList<T>? obj)
    {
        if (obj is null)
        {
            return default;
        }

        HashCode builder = new();

        for (int i = 0; i < obj.Count; i++)
        {
            var item = obj[i];
            builder.Add(item is null ? default : comparer.GetHashCode(item));
        }

        return builder.ToHashCode();
    }

    public bool Equals(List<T>? x, List<T>? y)
        =>
        Equals((IList<T>?)x, y);

    public int GetHashCode(List<T>? obj)
        =>
        GetHashCode((IList<T>?)obj);

    private static class InnerDefault
    {
        internal static readonly ListEqualityComparer<T> Value = Create();
    }
}
