using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ImmutableArrayEqualityComparer.Nullable;

// This class in intended to make xUnit not to merge test cases with collections equal by value
// (there is a difference between test cases with collections equal by value and by reference)
public sealed class CaseParam<T>
{
    public IList<T> Items { get; }

    public CaseParam(IList<T> items) => Items = items;
}
