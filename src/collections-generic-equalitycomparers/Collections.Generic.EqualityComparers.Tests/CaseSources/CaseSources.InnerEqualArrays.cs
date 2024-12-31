using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

partial class CaseSources
{
    private static IEnumerable<(T[]? X, T[]? Y)> InnerEqualArrays<T>()
    {
        if (typeof(T) == typeof(string))
        {
            return (IEnumerable<(T[]? X, T[]? Y)>)InnerEqualArraysOfString();
        }

        if (typeof(T) == typeof(int?))
        {
            return (IEnumerable<(T[]? X, T[]? Y)>)InnerEqualArraysOfInt32Nullable();
        }

        throw new ArgumentException($"An unexpected type ({typeof(T).Name}).", nameof(T));
    }
}
