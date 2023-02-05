using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class ArrayEqualityComparerTests_Ref_DefaultFactory : ArrayEqualityComparerTestsBase_Ref
{
    public ArrayEqualityComparerTests_Ref_DefaultFactory()
        : base(() => ArrayEqualityComparer<string>.Create())
    {
    }
}
