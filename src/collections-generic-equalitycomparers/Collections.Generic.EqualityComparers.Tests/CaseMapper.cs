using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

internal static class CaseMapper
{
    internal static CaseParamOfIReadOnlyList<T>[] MapToOfIReadOnlyList<T>(params CaseParamOfArray<T>[] @case)
        =>
        @case.Select(param => CaseParamMapper.MapToOfIReadOnlyList(param)).ToArray();

    internal static CaseParamOfIList<T>[] MapToOfIList<T>(params CaseParamOfArray<T>[] @case)
        =>
        @case.Select(param => CaseParamMapper.MapToOfIList(param)).ToArray();

    internal static CaseParamOfList<T>[] MapToOfList<T>(params CaseParamOfArray<T>[] @case)
    {
        var defaultEmpty = new List<T>();
        return @case.Select(param => CaseParamMapper.MapToOfList(param, () => defaultEmpty)).ToArray();
    }

    internal static CaseParamOfImmutableArray<T>[] MapToOfImmutableArray<T>(params CaseParamOfArray<T>[] @case)
        =>
        @case.Select(param => CaseParamMapper.MapToOfImmutableArray(param)).ToArray();

    internal static IEnumerable<CaseParamOfImmutableArrayNullable<T>[]> MapToOfImmutableArrayNullable<T>(
        params CaseParamOfArray<T>[] @case)
    {
        var param0 = @case[0];
        var param1 = @case[1];

        yield return new[]
        {
            CaseParamMapper.MapToOfImmutableArrayNullable(param0),
            CaseParamMapper.MapToOfImmutableArrayNullable(param1)
        };

        switch (param0.Items, param1.Items)
        {
            case (null, null):
                yield return new[]
                {
                    BuildWrappedDefaultCase(),
                    BuildWrappedDefaultCase()
                };
                break;

            case (null, _):
                yield return new[]
                {
                    BuildWrappedDefaultCase(),
                    CaseParamMapper.MapToOfImmutableArrayNullable(param1)
                };
                break;

            case (_, null):
                yield return new[]
                {
                    CaseParamMapper.MapToOfImmutableArrayNullable(param0),
                    BuildWrappedDefaultCase()
                };
                break;
        }

        static CaseParamOfImmutableArrayNullable<T> BuildWrappedDefaultCase()
            =>
            new(new ImmutableArray<T>?(default));
    }
}
