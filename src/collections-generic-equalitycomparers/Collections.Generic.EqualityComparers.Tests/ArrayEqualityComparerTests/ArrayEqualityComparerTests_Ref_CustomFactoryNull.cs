using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class ArrayEqualityComparerTests_Ref_CustomFactoryNull : ArrayEqualityComparerTestsBase_Ref
{
    public ArrayEqualityComparerTests_Ref_CustomFactoryNull()
        : base(() => ArrayEqualityComparer<string>.Create(null))
    {
    }
}
