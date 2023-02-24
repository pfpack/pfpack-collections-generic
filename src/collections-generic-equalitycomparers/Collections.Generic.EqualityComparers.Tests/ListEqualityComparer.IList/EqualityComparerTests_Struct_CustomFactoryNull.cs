using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ListEqualityComparer.IList;

public sealed class EqualityComparerTests_Struct_CustomFactoryNull : EqualityComparerTestsBase_Struct
{
    public EqualityComparerTests_Struct_CustomFactoryNull()
        : base(() => ListEqualityComparer<int>.Create(null))
    {
    }
}
