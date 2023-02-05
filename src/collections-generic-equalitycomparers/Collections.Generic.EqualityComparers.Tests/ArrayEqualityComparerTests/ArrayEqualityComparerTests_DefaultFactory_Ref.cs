using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class ArrayEqualityComparerTests_DefaultFactory_Ref : ArrayEqualityComparerTestsBase<string>
{
    public ArrayEqualityComparerTests_DefaultFactory_Ref()
        : base(() => ArrayEqualityComparer<string>.Create())
    {
    }
}
