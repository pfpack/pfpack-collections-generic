namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class CaseParamOfArray<T> : CaseParamBase<T, T[]>
{
    public CaseParamOfArray(T[]? items) : base(items)
    {
    }
}
