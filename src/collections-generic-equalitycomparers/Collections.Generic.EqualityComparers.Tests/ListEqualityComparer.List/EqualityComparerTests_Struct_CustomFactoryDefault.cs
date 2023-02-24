using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ListEqualityComparer.List;

public sealed class EqualityComparerTests_Struct_CustomFactoryDefault : EqualityComparerTestsBase_Struct
{
    public EqualityComparerTests_Struct_CustomFactoryDefault()
        : base(() => ReadOnlyListEqualityComparer<int>.Create(EqualityComparer<int>.Default))
    {
    }
}
