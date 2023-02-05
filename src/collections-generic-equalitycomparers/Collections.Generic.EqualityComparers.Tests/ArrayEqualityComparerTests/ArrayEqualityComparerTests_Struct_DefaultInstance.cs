using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class ArrayEqualityComparerTests_Struct_DefaultInstance : ArrayEqualityComparerTestsBase_Struct
{
    public ArrayEqualityComparerTests_Struct_DefaultInstance()
        : base(() => ArrayEqualityComparer<int>.Default)
    {
    }
}
