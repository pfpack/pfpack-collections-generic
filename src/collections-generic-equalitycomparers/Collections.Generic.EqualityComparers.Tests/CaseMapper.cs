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
}
