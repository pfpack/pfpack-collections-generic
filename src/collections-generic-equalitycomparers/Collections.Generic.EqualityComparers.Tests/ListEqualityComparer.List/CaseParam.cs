using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ListEqualityComparer.List;

// This class in intended to make xUnit not to merge test cases with collections equal by value
// (there is a difference between test cases with collections equal by value and by reference)
public sealed class CaseParam<T>
{
    public List<T>? Items { get; }

    public CaseParam(List<T>? items) => Items = items;
}
