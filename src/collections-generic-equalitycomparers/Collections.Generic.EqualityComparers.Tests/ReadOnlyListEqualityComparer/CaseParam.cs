using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ReadOnlyListEqualityComparer;

public sealed class CaseParam<T> : CaseParamBase<T, IReadOnlyList<T>>
{
    public CaseParam(IReadOnlyList<T>? items) : base(items)
    {
    }
}
