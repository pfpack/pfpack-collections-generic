using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

internal static class CaseParamMapper
{
    internal static CaseParamOfIReadOnlyList<T> MapToOfIReadOnlyList<T>(CaseParamOfArray<T> param)
        =>
        new(InnerMapCase(
            param.Items,
            () => null,
            () => CustomReadOnlyList<T>.Empty,
            items => new CustomReadOnlyList<T>(items)));

    internal static CaseParamOfIList<T> MapToOfIList<T>(CaseParamOfArray<T> param)
        =>
        new(InnerMapCase(
            param.Items,
            () => null,
            () => CustomList<T>.Empty,
            items => new CustomList<T>(items)));

    internal static CaseParamOfList<T> MapToOfList<T>(CaseParamOfArray<T> param, Func<List<T>> defaultEmptySupplier)
        =>
        new(InnerMapCase(
            param.Items,
            () => null,
            defaultEmptySupplier,
            items => new List<T>(items)));

    internal static CaseParamOfImmutableArray<T> MapToOfImmutableArray<T>(CaseParamOfArray<T> param)
        =>
        new(InnerMapCase(
            param.Items,
            () => default,
            () => ImmutableArray<T>.Empty,
            items => ImmutableArray.Create(items)));

    internal static CaseParamOfImmutableArrayNullable<T> MapToOfImmutableArrayNullable<T>(CaseParamOfArray<T> param)
        =>
        new(InnerMapCase(
            param.Items,
            () => default(ImmutableArray<T>?),
            () => ImmutableArray<T>.Empty,
            items => ImmutableArray.Create(items)));

    private static TResult? InnerMapCase<T, TResult>(
        T[]? items,
        Func<TResult?> nullSupplier,
        Func<TResult> defaultEmptySupplier,
        Func<T[], TResult> map)
        =>
        items switch
        {
            null => nullSupplier.Invoke(),
            _ when ReferenceEquals(items, EmptyArray<T>.Value) => defaultEmptySupplier.Invoke(),
            _ => map.Invoke(items)
        };
}
