using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

internal static class CaseParamMapper
{
    internal static CaseParamOfIReadOnlyList<T> MapToOfIReadOnlyList<T>(CaseParamOfArray<T> caseParam)
        =>
        new(InnerMap(
            caseParam.Items,
            () => CustomReadOnlyList<T>.Empty,
            items => new CustomReadOnlyList<T>(items)));

    internal static CaseParamOfIList<T> MapToOfIList<T>(CaseParamOfArray<T> caseParam)
        =>
        new(InnerMap(
            caseParam.Items,
            () => CustomList<T>.Empty,
            items => new CustomList<T>(items)));

    internal static CaseParamOfList<T> MapToOfList<T>(CaseParamOfArray<T> caseParam, Func<List<T>> defaultEmptySupplier)
        =>
        new(InnerMap(
            caseParam.Items,
            defaultEmptySupplier,
            items => new List<T>(items)));

    private static TResult? InnerMap<T, TResult>(
        T[]? items, Func<TResult> defaultEmptySupplier, Func<T[], TResult> map)
        where TResult : IEnumerable<T>
        =>
        items switch
        {
            null => default,
            _ when ReferenceEquals(items, EmptyArray<T>.Value) => defaultEmptySupplier.Invoke(),
            _ => map.Invoke(items)
        };
}
