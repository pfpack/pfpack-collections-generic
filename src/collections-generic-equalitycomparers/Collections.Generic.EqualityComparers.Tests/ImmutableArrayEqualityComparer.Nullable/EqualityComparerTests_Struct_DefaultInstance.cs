using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ImmutableArrayEqualityComparer.Nullable;

public sealed class EqualityComparerTests_Struct_DefaultInstance : EqualityComparerTestsBase_Struct
{
    public EqualityComparerTests_Struct_DefaultInstance()
        : base(() => ImmutableArrayEqualityComparer<int?>.Default)
    {
    }
}
