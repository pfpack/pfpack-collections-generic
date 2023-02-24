namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ArrayEqualityComparer;

public sealed class CaseParam<T>
{
    public T[] Items { get; }

    public CaseParam(T[] items) => Items = items;
}
