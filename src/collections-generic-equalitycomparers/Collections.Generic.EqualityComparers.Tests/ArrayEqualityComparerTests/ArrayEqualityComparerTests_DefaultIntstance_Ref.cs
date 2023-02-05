using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class ArrayEqualityComparerTests_DefaultIntstance_Ref : ArrayEqualityComparerTestsBase_Ref
{
    public ArrayEqualityComparerTests_DefaultIntstance_Ref()
        : base(() => ArrayEqualityComparer<string>.Default)
    {
    }
}
