namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ArrayEqualityComparer;

public sealed class CaseParam<T> : CaseParamBase<T, T[]>
{
    public CaseParam(T[]? items) : base(items)
    {
    }
}
