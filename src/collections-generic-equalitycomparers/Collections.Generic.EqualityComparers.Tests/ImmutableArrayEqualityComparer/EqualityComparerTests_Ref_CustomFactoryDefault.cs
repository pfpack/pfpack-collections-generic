using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ImmutableArrayEqualityComparer;

public sealed class EqualityComparerTests_Ref_CustomFactoryDefault : EqualityComparerTestsBase_Ref
{
    public EqualityComparerTests_Ref_CustomFactoryDefault()
        : base(() => ImmutableArrayEqualityComparer<string?>.Create(EqualityComparer<string?>.Default))
    {
    }
}
