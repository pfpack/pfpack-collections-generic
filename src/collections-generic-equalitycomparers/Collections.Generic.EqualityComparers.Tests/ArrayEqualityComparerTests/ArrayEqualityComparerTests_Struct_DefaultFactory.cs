using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class ArrayEqualityComparerTests_Struct_DefaultFactory : ArrayEqualityComparerTestsBase_Struct
{
    public ArrayEqualityComparerTests_Struct_DefaultFactory()
        : base(() => ArrayEqualityComparer<int>.Create())
    {
    }
}
