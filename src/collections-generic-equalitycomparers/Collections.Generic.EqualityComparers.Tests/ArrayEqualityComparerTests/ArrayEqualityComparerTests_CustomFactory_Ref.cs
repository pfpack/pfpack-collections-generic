using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class ArrayEqualityComparerTests_CustomFactory_Ref : ArrayEqualityComparerTestsBase_Ref
{
    public ArrayEqualityComparerTests_CustomFactory_Ref()
        : base(() => ArrayEqualityComparer<string>.Create(EqualityComparer<string>.Default))
    {
    }
}
