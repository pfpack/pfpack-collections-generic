using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ImmutableArrayEqualityComparer.Nullable;

public sealed class EqualityComparerTests_Struct_CustomFactoryDefault : EqualityComparerTestsBase_Struct
{
    public EqualityComparerTests_Struct_CustomFactoryDefault()
        : base(() => ImmutableArrayEqualityComparer<int?>.Create(EqualityComparer<int?>.Default))
    {
    }
}
