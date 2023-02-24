namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ArrayEqualityComparer;

// This class in intended to make xUnit not to merge test cases with collections equal by value
// (there is a difference between test cases with collections equal by value and by reference)
public sealed class CaseParam<T>
{
    public T[]? Items { get; }

    public CaseParam(T[]? items) => Items = items;
}
