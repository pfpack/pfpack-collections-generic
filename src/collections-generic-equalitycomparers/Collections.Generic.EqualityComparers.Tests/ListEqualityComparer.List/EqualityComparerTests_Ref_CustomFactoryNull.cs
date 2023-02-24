using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ListEqualityComparer.List;

public sealed class EqualityComparerTests_Ref_CustomFactoryNull : EqualityComparerTestsBase_Ref
{
    public EqualityComparerTests_Ref_CustomFactoryNull()
        : base(() => ReadOnlyListEqualityComparer<string>.Create(null))
    {
    }
}
