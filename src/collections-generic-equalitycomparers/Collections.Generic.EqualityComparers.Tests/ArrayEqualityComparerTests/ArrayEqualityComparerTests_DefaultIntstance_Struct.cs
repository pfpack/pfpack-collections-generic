using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class ArrayEqualityComparerTests_DefaultIntstance_Struct : ArrayEqualityComparerTestsBase_Struct
{
    public ArrayEqualityComparerTests_DefaultIntstance_Struct()
        : base(() => ArrayEqualityComparer<int>.Default)
    {
    }
}
