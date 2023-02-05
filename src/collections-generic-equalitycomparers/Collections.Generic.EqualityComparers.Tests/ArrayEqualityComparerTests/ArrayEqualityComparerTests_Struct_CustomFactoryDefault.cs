using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class ArrayEqualityComparerTests_Struct_CustomFactoryDefault : ArrayEqualityComparerTestsBase_Struct
{
    public ArrayEqualityComparerTests_Struct_CustomFactoryDefault()
        : base(() => ArrayEqualityComparer<int>.Create(EqualityComparer<int>.Default))
    {
    }
}
