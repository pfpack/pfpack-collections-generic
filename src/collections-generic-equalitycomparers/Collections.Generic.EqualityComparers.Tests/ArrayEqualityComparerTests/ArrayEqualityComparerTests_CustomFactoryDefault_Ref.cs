using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class ArrayEqualityComparerTests_CustomFactoryDefault_Ref : ArrayEqualityComparerTestsBase_Ref
{
    public ArrayEqualityComparerTests_CustomFactoryDefault_Ref()
        : base(() => ArrayEqualityComparer<string>.Create(null))
    {
    }
}
