using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class ArrayEqualityComparerTests_DefaultIntstance_Struct : ArrayEqualityComparerTestsBase<int>
{
    public ArrayEqualityComparerTests_DefaultIntstance_Struct()
        : base(() => ArrayEqualityComparer<int>.Default)
    {
    }
}
