using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class CaseParamOfIList<T> : CaseParamBase<T, IList<T>>
{
    public CaseParamOfIList(IList<T>? items) : base(items)
    {
    }
}
