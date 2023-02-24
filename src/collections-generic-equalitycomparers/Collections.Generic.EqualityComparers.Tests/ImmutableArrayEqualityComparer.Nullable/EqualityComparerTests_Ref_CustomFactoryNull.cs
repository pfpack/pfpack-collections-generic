using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ImmutableArrayEqualityComparer.Nullable;

public sealed class EqualityComparerTests_Ref_CustomFactoryNull : EqualityComparerTestsBase_Ref
{
    public EqualityComparerTests_Ref_CustomFactoryNull()
        : base(() => ListEqualityComparer<string>.Create(null))
    {
    }
}
