using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class ArrayEqualityComparerTests_DefaultFactory_Ref : ArrayEqualityComparerTestsBase_Ref
{
    public ArrayEqualityComparerTests_DefaultFactory_Ref()
        : base(() => ArrayEqualityComparer<string>.Create())
    {
    }
}
