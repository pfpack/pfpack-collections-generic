using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ImmutableArrayEqualityComparer.Nullable;

public sealed class EqualityComparerTests_Struct_CustomFactory : EqualityComparerTestsBase_Struct
{
    public EqualityComparerTests_Struct_CustomFactory()
        : base(() => ListEqualityComparer<int>.Create(CustomEqualityComparer<int>.Default))
    {
    }
}
