using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

// This class in intended to make xUnit not to merge test cases with collections equal by value
// (there is a difference between test cases with collections equal by value and by reference)
public abstract class CaseParamBase<TItem, TCollection> where TCollection : IEnumerable<TItem>
{
    public TCollection? Items { get; }

    public CaseParamBase(TCollection? items) => Items = items;
}
