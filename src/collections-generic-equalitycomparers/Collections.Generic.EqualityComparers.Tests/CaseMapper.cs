using System.Collections.Generic;
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

    internal static IEnumerable<CaseParamOfImmutableArrayNullable<T>[]> MapToOfImmutableArrayNullable<T>(params CaseParamOfArray<T>[] @case)
    {
        yield return @case.Select(param => CaseParamMapper.MapToOfImmutableArrayNullable(param)).ToArray();
        yield return @case.Select(param => CaseParamMapper.MapToOfImmutableArrayWrapped(param)).ToArray();
        yield return new[]
        {
            CaseParamMapper.MapToOfImmutableArrayNullable(@case[0]),
            CaseParamMapper.MapToOfImmutableArrayWrapped(@case[1])
        };
        yield return new[]
        {
            CaseParamMapper.MapToOfImmutableArrayWrapped(@case[0]),
            CaseParamMapper.MapToOfImmutableArrayNullable(@case[1])
        };
    }
}
