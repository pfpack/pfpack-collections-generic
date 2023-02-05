using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class ArrayEqualityComparerTests_Ref_DefaultInstance : ArrayEqualityComparerTestsBase_Ref
{
    public ArrayEqualityComparerTests_Ref_DefaultInstance()
        : base(() => ArrayEqualityComparer<string>.Default)
    {
    }
}
