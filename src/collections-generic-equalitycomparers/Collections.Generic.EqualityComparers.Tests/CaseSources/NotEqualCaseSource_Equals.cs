using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

internal static partial class NotEqualCaseSource_Equals
{
    internal static IEnumerable<(T[]? X, T[]? Y)> NotEqualArrays<T>()
        =>
        InnerNotEqualArrays<T>().ToArray() switch
        {
            var pairs => pairs.Concat(pairs.Select(pair => (pair.Y, pair.X)))
        };

    private static IEnumerable<(T[]? X, T[]? Y)> InnerNotEqualArrays<T>()
    {
        if (typeof(T) == typeof(string))
        {
            return (IEnumerable<(T[]? X, T[]? Y)>)InnerNotEqualArraysOfString();
        }

        if (typeof(T) == typeof(int?))
        {
            return (IEnumerable<(T[]? X, T[]? Y)>)InnerNotEqualArraysOfInt32Nullable();
        }

        throw new ArgumentException($"An unexpected type ({typeof(T).Name}).", nameof(T));
    }
}
