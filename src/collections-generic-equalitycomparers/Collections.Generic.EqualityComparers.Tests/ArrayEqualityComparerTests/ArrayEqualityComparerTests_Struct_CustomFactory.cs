using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class ArrayEqualityComparerTests_Struct_CustomFactory : ArrayEqualityComparerTestsBase_Struct
{
    public ArrayEqualityComparerTests_Struct_CustomFactory()
        : base(() => ArrayEqualityComparer<int>.Create(CustomEqualityComparer<int>.Default))
    {
    }
}
