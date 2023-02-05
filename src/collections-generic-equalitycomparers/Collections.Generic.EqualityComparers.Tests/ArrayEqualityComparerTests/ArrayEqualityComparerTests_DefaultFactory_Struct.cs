using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class ArrayEqualityComparerTests_DefaultFactory_Struct : ArrayEqualityComparerTestsBase_Struct
{
    public ArrayEqualityComparerTests_DefaultFactory_Struct()
        : base(() => ArrayEqualityComparer<int>.Create())
    {
    }
}
