using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ImmutableArrayEqualityComparer;

public sealed class EqualityComparerTests_Struct_CustomFactoryNull : EqualityComparerTestsBase_Struct
{
    public EqualityComparerTests_Struct_CustomFactoryNull()
        : base(() => ImmutableArrayEqualityComparer<int?>.Create(null))
    {
    }
}
