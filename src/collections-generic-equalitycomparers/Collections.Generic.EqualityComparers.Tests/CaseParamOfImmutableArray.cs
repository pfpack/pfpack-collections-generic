using System.Collections.Immutable;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class CaseParamOfImmutableArray<T> : CaseParamBase<T, ImmutableArray<T>>
{
    public CaseParamOfImmutableArray(ImmutableArray<T> items) : base(items)
    {
    }
}
