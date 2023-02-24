using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ListEqualityComparer.IList;

public sealed class EqualityComparerTests_Ref_DefaultInstance : EqualityComparerTestsBase_Ref
{
    public EqualityComparerTests_Ref_DefaultInstance()
        : base(() => ListEqualityComparer<string>.Default)
    {
    }
}
