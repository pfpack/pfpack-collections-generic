using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

internal static partial class NotEqualCaseSource_GetHashCode
{
    // Here it is assumed a small set consisting of short arrays
    // should lead to different hash codes with no collisions
    internal static IEnumerable<(T[]? X, T[]? Y)> NotEqualArrays<T>()
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
