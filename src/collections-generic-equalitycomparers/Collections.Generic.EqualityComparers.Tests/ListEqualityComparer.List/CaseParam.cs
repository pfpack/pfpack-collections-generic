using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ListEqualityComparer.List;

public sealed class CaseParam<T> : CaseParamBase<T, List<T>>
{
    public CaseParam(List<T>? items) : base(items)
    {
    }
}
