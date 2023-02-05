using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class ArrayEqualityComparerTests_CustomFactoryDefault_Struct : ArrayEqualityComparerTestsBase_Struct
{
    public ArrayEqualityComparerTests_CustomFactoryDefault_Struct()
        : base(() => ArrayEqualityComparer<int>.Create(null))
    {
    }
}
