using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

partial class CaseSources
{
    internal static IEnumerable<(T[]? X, T[]? Y)> Equals_NotEqualArrays<T>()
    {
        var pairs = InnerEnumerate().ToArray();
        return pairs.Concat(pairs.Select(pair => (pair.Y, pair.X)));

        static IEnumerable<(T[]? X, T[]? Y)> InnerEnumerate()
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
}
