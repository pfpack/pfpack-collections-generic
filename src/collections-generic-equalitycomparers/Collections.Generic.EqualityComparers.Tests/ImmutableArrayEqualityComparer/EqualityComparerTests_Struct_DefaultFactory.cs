using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ImmutableArrayEqualityComparer;

public sealed class EqualityComparerTests_Struct_DefaultFactory : EqualityComparerTestsBase_Struct
{
    public EqualityComparerTests_Struct_DefaultFactory()
        : base(() => ImmutableArrayEqualityComparer<int?>.Create())
    {
    }
}
