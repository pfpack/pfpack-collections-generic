using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ListEqualityComparer.IList;

public sealed class CaseParam<T> : CaseParamBase<T, IList<T>>
{
    public CaseParam(IList<T>? items) : base(items)
    {
    }
}
