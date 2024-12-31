using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

partial class CaseSources
{
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
