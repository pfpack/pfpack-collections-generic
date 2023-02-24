using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ReadOnlyListEqualityComparer;

public sealed class EqualityComparerTests_Struct_CustomFactoryNull : EqualityComparerTestsBase_Struct
{
    public EqualityComparerTests_Struct_CustomFactoryNull()
        : base(() => ReadOnlyListEqualityComparer<int>.Create(null))
    {
    }
}
