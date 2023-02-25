using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class CaseParamOfIReadOnlyList<T> : CaseParamBase<T, IReadOnlyList<T>>
{
    public CaseParamOfIReadOnlyList(IReadOnlyList<T>? items) : base(items)
    {
    }
}
