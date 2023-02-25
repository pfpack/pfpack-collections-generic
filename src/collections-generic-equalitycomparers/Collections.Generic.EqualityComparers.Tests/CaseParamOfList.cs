using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class CaseParamOfList<T> : CaseParamBase<T, List<T>>
{
    public CaseParamOfList(List<T>? items) : base(items)
    {
    }
}
