using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

internal static class CaseParamsMapper
{
    internal static (CaseParamOfIReadOnlyList<T> X, CaseParamOfIReadOnlyList<T> Y) MapToOfIReadOnlyList<T>(
        T[]? x,
        T[]? y)
        =>
        InnerMap(
            x,
            y,
            items => new CustomReadOnlyList<T>(items),
            result => new CaseParamOfIReadOnlyList<T>(result));

    internal static (CaseParamOfIList<T> X, CaseParamOfIList<T> Y) MapToOfIList<T>(
        T[]? x,
        T[]? y)
        =>
        InnerMap(
            x,
            y,
            items => new CustomList<T>(items),
            result => new CaseParamOfIList<T>(result));

    internal static (CaseParamOfList<T> X, CaseParamOfList<T> Y) MapToOfList<T>(
        T[]? x,
        T[]? y)
        =>
        InnerMap(
            x,
            y,
            items => new List<T>(items),
            result => new CaseParamOfList<T>(result));

    internal static (CaseParamOfImmutableArray<T> X, CaseParamOfImmutableArray<T> Y) MapToOfImmutableArray<T>(
        T[]? x,
        T[]? y)
        =>
        InnerMap(
            x,
            y,
            items => ImmutableArray.Create(items),
            result => new CaseParamOfImmutableArray<T>(result));

    internal static IEnumerable<(CaseParamOfImmutableArrayNullable<T> X, CaseParamOfImmutableArrayNullable<T> Y)> MapToOfImmutableArrayNullable<T>(
        T[]? x,
        T[]? y)
    {
        switch (x, y)
        {
            case (null, null):
                yield return (
                    new(null),
                    new(null));
                yield return (
                    new(null),
                    new(new ImmutableArray<T>?(default)));
                yield return (
                    new(new ImmutableArray<T>?(default)),
                    new(null));
                yield return (
                    new(new ImmutableArray<T>?(default)),
                    new(new ImmutableArray<T>?(default)));
                yield break;

            case (null, _):
                yield return (
                    new(null),
                    new(ImmutableArray.Create(y)));
                yield return (
                    new(new ImmutableArray<T>?(default)),
                    new(ImmutableArray.Create(y)));
                yield break;

            case (_, null):
                yield return (
                    new(ImmutableArray.Create(x)),
                    new(null));
                yield return (
                    new(ImmutableArray.Create(x)),
                    new(new ImmutableArray<T>?(default)));
                yield break;

            case (_, _) when ReferenceEquals(x, y):
                var array = ImmutableArray.Create(x);
                yield return (
                    new(array),
                    new(array));
                yield break;

            case (_, _):
                yield return (
                    new(ImmutableArray.Create(x)),
                    new(ImmutableArray.Create(y)));
                yield break;
        }
    }

    private static (TCaseParam X, TCaseParam Y) InnerMap<T, TCollection, TCaseParam>(
        T[]? x,
        T[]? y,
        Func<T[], TCollection> buildCollection,
        Func<TCollection?, TCaseParam> buildCaseParam)
    {
        switch (x, y)
        {
            case (null, null):
                return (buildCaseParam(default), buildCaseParam(default));

            case (null, _):
                return (buildCaseParam(default), buildCaseParam(buildCollection(y)));

            case (_, null):
                return (buildCaseParam(buildCollection(x)), buildCaseParam(default));

            case (_, _) when ReferenceEquals(x, y):
                var collection = buildCollection(x);
                return (buildCaseParam(collection), buildCaseParam(collection));

            case (_, _):
                return (buildCaseParam(buildCollection(x)), buildCaseParam(buildCollection(y)));
        };
    }
}
