using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class ArrayEqualityComparerTests_Struct_CustomFactoryNull : ArrayEqualityComparerTestsBase_Struct
{
    public ArrayEqualityComparerTests_Struct_CustomFactoryNull()
        : base(() => ArrayEqualityComparer<int>.Create(null))
    {
    }
}
