using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ImmutableArrayEqualityComparer;

public sealed class EqualityComparerTests_Struct_CustomFactory : EqualityComparerTestsBase_Struct
{
    public EqualityComparerTests_Struct_CustomFactory()
        : base(() => ImmutableArrayEqualityComparer<int?>.Create(CustomEqualityComparer<int?>.Default))
    {
    }
}
